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
    public class MutableServiceTests
    {
        public class TestReadOnlyService : MutableService<UserContract>
        {
            public TestReadOnlyService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) : base(configuration, webRequestFactory, keyService)
            {
            }

            public override string Route
            {
                get { return "Test/User/Contract"; }
            }
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private TestReadOnlyService _service;
        private static Guid _uid;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new TestReadOnlyService(_configuration, _webFactory, null);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>[] _deleteActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>("Delegate", 
                    (service, cf) =>
                    {
                        var ret = false;
                        service.Delete(cf, _uid, null, (code) => { ret = true; }, (uri, exception) => Assert.Fail(exception.Message));
                        return ret;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>("Sync", 
                    (service, cf) =>
                    {
                        service.Delete(cf, _uid, null);
                        return true;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>("Async", 
                    (service, cf) =>
                    {
                        service.DeleteAsync(cf, _uid, null);
                        return true;
                    }),
            };


        [Test]
        public void WeDeleteContactUsingCompanyFileBaseUrl([ValueSource("_deleteActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid, null);

            // act
            var ret = action.Item2(_service, cf);

            // assert
            Assert.IsTrue(ret, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>[] _postActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Insert(cf, new UserContract() {UID = UID}, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Insert(cf, new UserContract() {UID = UID}, null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.InsertAsync(cf, new UserContract() {UID = UID}, null).Result;
                    }),
            };


        [Test]
        public void WePostContactUsingCompanyFileBaseUrl([ValueSource("_postActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract", null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }

        protected static Guid UID = Guid.NewGuid();

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>[] _putActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new UserContract() { UID = UID }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new UserContract() { UID = UID }, null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new UserContract() { UID = UID }, null).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl([ValueSource("_putActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID, null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }

    }
}
