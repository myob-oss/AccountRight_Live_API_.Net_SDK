using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Services.Sale;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using System.IO.Compression;
    
namespace SDK.Test.Services
{
    [TestFixture]
    public class PdfInvoiceServiceBaseTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private TestInvoiceService _service;
        private static Guid _uid;
        private const string Route = "Dummy";

        public class TestInvoiceService : PdfInvoiceServiceBase<BaseEntity>
        {
            public TestInvoiceService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
                : base(configuration, webRequestFactory, keyService)
            {
            }

            internal override string Route
            {
                get { return PdfInvoiceServiceBaseTests.Route; }
            }
        }

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new TestInvoiceService(_configuration, _webFactory, null);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private readonly Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>>[] _getFormPdfActions = new[]
            {
                new Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>>("Delegate", 
                                                                                 (service, cf) =>
                                                                                     {
                                                                                         Stream received = null;
                                                                                         service.GetInvoiceFormAsPdf(cf, _uid, null, "tn", (code, data) => { received = data; }, (uri, exception) => Assert.Fail(exception.Message));
                                                                                         return received;
                                                                                     }),
                new Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>>("Sync", 
                                                                                 (service, cf) =>
                                                                                     {
                                                                                         return service.GetInvoiceFormAsPdf(cf, _uid, null, "tn");
                                                                                     }),
                new Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>>("Async", 
                                                                                 (service, cf) =>
                                                                                     {
                                                                                         return service.GetInvoiceFormAsPdfAsync(cf, _uid, null, "tn").Result;
                                                                                     }),
            };

        [Test]
        public void GetInvoiceFormAsPdf_NoGZip_ReturnsSimpleStream([ValueSource("_getFormPdfActions")] Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>> action)
        {
            // Arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var stream = new MemoryStream(new byte[] { 0, 1, 2, 3 });
            var uri = cf.Uri.AbsoluteUri + "/" + Route + "/" + _uid + "?templatename=tn";
            _webFactory.RegisterResultForUri(uri, stream);

            // Act
            var received = action.Item2(_service, cf);

            // Assert
            Assert.AreEqual(stream, received, "Incorrect data received during {0} operation", action.Item1);
        }

        [Test]
        public void GetInvoiceFormAsPdf_GZipped_ReturnsGZippedStream([ValueSource("_getFormPdfActions")] Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>> action)
        {
            // Arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var expectedPdf = new MemoryStream(new byte[] { 0, 1, 2, 3 });
            var uri = cf.Uri.AbsoluteUri + "/" + Route + "/" + _uid + "?templatename=tn";
            _webFactory.RegisterCompressedResultForUri(uri, expectedPdf);

            // Act
            var received = action.Item2(_service, cf);

            // Assert
            Assert.IsInstanceOf<GZipStream>(received);
            using (var actualPdf = new MemoryStream())
            {
                received.CopyTo(actualPdf);
                Assert.AreEqual(expectedPdf, actualPdf);
            }
        }

        [Test]
        public void GetInvoiceFormAsPdf_Sync_ThrowsInvalidOperationException()
        {
            // Arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var uri = cf.Uri.AbsoluteUri + "/" + Route + "/" + _uid + "?templatename=tn";
            _webFactory.RegisterExceptionForUri<WebException>(uri);

            var iis = new TestInvoiceService(_configuration, _webFactory, null);

            // Act
            var ex = Assert.Throws<ApiCommunicationException>(() => iis.GetInvoiceFormAsPdf(cf, _uid, null, "tn"));

            // Assert
            Assert.AreEqual(uri.ToLower(), ex.URI.AbsoluteUri.ToLower());
            Assert.IsInstanceOf<InvalidOperationException>(ex.InnerException);
        }

        [Test]
        public void GetInvoiceFormAsPdf_AsyncWithDelegates_ThrowsWebException()
        {
            // Arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var uri = cf.Uri.AbsoluteUri + "/" + Route + "/" + _uid + "?templatename=tn";
            _webFactory.RegisterExceptionForUri<WebException>(uri);

            var iis = new TestInvoiceService(_configuration, _webFactory, null);

            // Act
            iis.GetInvoiceFormAsPdf(cf, _uid, null, "tn", (c, s) => Assert.Fail("Exception Expected"), (
                u, e) => Assert.IsNotNull(e as WebException));

        }

        [Test]
        public void GetInvoiceFormAsPdf_AsyncWithTask_ThrowsWebException()
        {
            // Arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var uri = cf.Uri.AbsoluteUri + "/" + Route + "/" + _uid + "?templatename=tn";
            _webFactory.RegisterExceptionForUri<WebException>(uri);

            var iis = new TestInvoiceService(_configuration, _webFactory, null);

            // Act
            var task = iis.GetInvoiceFormAsPdfAsync(cf, _uid, null, "tn").ContinueWith(t =>
                {
                    Assert.IsNotNull(t.Exception);
                    Assert.IsNotNull(t.Exception.InnerException);
                    Assert.IsInstanceOf<WebException>(t.Exception.InnerException);
                });

            // Assert
            Task.WaitAll(new[] { task });
        }      

        [Test]
        public void GetInvoiceFormAsPdf_UsesCorrectMimeType_ToCreate_WebRequestObject(
            [ValueSource("_getFormPdfActions")] Tuple<string, Func<TestInvoiceService, CompanyFile, Stream>> action)
        {
            // arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var stream = new MemoryStream(new byte[] { 0, 1, 2, 3 });
            var uri = cf.Uri.AbsoluteUri + "/" + Route + "/" + _uid + "?templatename=tn";
            _webFactory.RegisterResultForUri(uri, stream);

            var webRequestFactory = Substitute.For<IWebRequestFactory>();
            webRequestFactory.Create(Arg.Any<Uri>(), Arg.Any<string>()).Returns(x => _webFactory.Create((Uri)x[0], (string)x[1]));
            
            var iis = new TestInvoiceService(_configuration, webRequestFactory, null);

            // Act
            action.Item2(iis, cf);

            // assert
            webRequestFactory.Received(1).Create(Arg.Any<Uri>(), "application/pdf");
        }
    }
}