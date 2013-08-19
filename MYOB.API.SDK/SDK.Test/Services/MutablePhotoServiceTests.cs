using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class MutablePhotoServiceTests
    {
        public class TestPhotoService : MutablePhotoService<UserContract>
        {
            public TestPhotoService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
                : base(configuration, webRequestFactory, keyService)
            {
            }

            public override string Route
            {
                get { return "Test/User/Contract"; }
            }
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private TestPhotoService _service;
        private static Guid _uid;

        protected static Guid UID = Guid.NewGuid();
        protected static byte[] ImageData = new byte[] {0, 1, 2, 3, 5, 7, 11, 13};

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new TestPhotoService(_configuration, _webFactory, null);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private readonly Tuple<string, Func<TestPhotoService, CompanyFile, byte[]>>[] _getPhotoActions = new[]
            {
                new Tuple<string, Func<TestPhotoService, CompanyFile, byte[]>>("Async", 
                    (service, cf) =>
                    {
                        byte[] received = null;
                        service.GetPhoto(cf, _uid, null, (code, data) => { received = data; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestPhotoService, CompanyFile, byte[]>>("Sync", 
                    (service, cf) =>
                    {
                        return service.GetPhoto(cf, _uid, null);
                    }),
            };


        [Test]
        public void WeGetContactPhotoUsingCompanyFileBaseUrl([ValueSource("_getPhotoActions")] Tuple<string, Func<TestPhotoService, CompanyFile, byte[]>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var photo = new Photo() {Data = new byte[] {0, 1, 2, 3}};
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid + "/Photo", photo.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(photo.Data, received, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestPhotoService, CompanyFile, bool>>[] _deletePhotoActions = new[]
            {
                new Tuple<string, Func<TestPhotoService, CompanyFile, bool>>("Async", 
                    (service, cf) =>
                        {
                            var ret = false;
                            service.DeletePhoto(cf, _uid, null, (code) => { ret = true; }, (uri, exception) => Assert.Fail(exception.Message));
                            return ret;
                        }),
                new Tuple<string, Func<TestPhotoService, CompanyFile, bool>>("Sync", 
                    (service, cf) =>
                    {
                        service.DeletePhoto(cf, _uid, null);
                        return true;
                    }),
            };


        [Test]
        public void WeDeleteContactPhotoUsingCompanyFileBaseUrl([ValueSource("_deletePhotoActions")] Tuple<string, Func<TestPhotoService, CompanyFile, bool>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid + "/Photo", null);

            // act
            var ret = action.Item2(_service, cf);

            // assert
            Assert.IsTrue(ret, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestPhotoService, CompanyFile, string>>[] _postPhotoActions = new[]
            {
                new Tuple<string, Func<TestPhotoService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.SavePhoto(cf, UID, ImageData, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestPhotoService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.SavePhoto(cf, UID, ImageData, null);
                    }),
            };


        [Test]
        public void WePostContactUsingCompanyFileBaseUrl([ValueSource("_postPhotoActions")] Tuple<string, Func<TestPhotoService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID + "/Photo";
            _webFactory.RegisterResultForUri(location, null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }


    }
}
