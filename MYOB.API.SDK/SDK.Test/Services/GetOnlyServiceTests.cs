using System;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class GetOnlyServiceTests
    {
        public class TestGetOnlyService : GetOnlyService<UserContract>
        {
            public TestGetOnlyService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService = null)
                : base(configuration, webRequestFactory, keyService)
            {
            }

            internal override string Route
            {
                get { return "Test/User/Contract"; }
            }
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private TestGetOnlyService _service;
        private Guid _uid;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new TestGetOnlyService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private readonly Tuple<string, Func<TestGetOnlyService, CompanyFile, UserContract>>[] _testGetOnlyActions = new[]
            {
                new Tuple<string, Func<TestGetOnlyService, CompanyFile, UserContract>>("Delegate", 
                                                                                       (service, cf) =>
                                                                                           {
                                                                                               UserContract received = null;
                                                                                               service.Get(cf, null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                                                                                               return received;
                                                                                           }),
                new Tuple<string, Func<TestGetOnlyService, CompanyFile, UserContract>>("Sync", 
                                                                                       (service, cf) => service.Get(cf, null)),
                new Tuple<string, Func<TestGetOnlyService, CompanyFile, UserContract>>("Async", 
                                                                                       (service, cf) => service.GetAsync(cf, null).Result)
            };

        [Test]
        public void GetCompanyUsingCompanyFileBaseUrl([ValueSource("_testGetOnlyActions")] Tuple<string, Func<TestGetOnlyService, CompanyFile, UserContract>> action)
        {
            //arrange
            var contract = new UserContract { UID = _uid };
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract", contract.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(_uid, received.UID, "Incorrect data received during {0} operation", action.Item1);
        }
    }
}