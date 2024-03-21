using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Contact;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ContactServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact", new ContactService(null, null).Route);
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private ContactService _service;
        private static Guid _uid;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new ContactService(_configuration, _webFactory, null);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private static readonly Tuple<string, Func<ContactService, CompanyFile, byte[]>>[] _getPhotoActions = new[]
            {
                new Tuple<string, Func<ContactService, CompanyFile, byte[]>>("Delegate", 
                    (service, cf) =>
                    {
                        byte[] received = null;
                        service.GetPhoto(cf, _uid, null, (code, data) => { received = data; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<ContactService, CompanyFile, byte[]>>("Sync", 
                    (service, cf) =>
                    {
                        return service.GetPhoto(cf, _uid, null);
                    }),
                new Tuple<string, Func<ContactService, CompanyFile, byte[]>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetPhotoAsync(cf, _uid, null).Result;
                    }),
            };


        [Test]
        public void WeGetContactPhotoUsingCompanyFileBaseUrl([ValueSource("_getPhotoActions")] Tuple<string, Func<ContactService, CompanyFile, byte[]>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var photo = new Photo() {Data = new byte[] {0, 1, 2, 3}};
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Contact/" + _uid + "/Photo", photo.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(photo.Data, received, "Incorrect data received during {0} operation", action.Item1);
        }


    }
}
