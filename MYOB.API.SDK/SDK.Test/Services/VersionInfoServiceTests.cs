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
    public class VersionInfoServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private VersionInfoService _service;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new VersionInfoService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }

        private readonly Tuple<string, Func<VersionInfoService, VersionInfo>>[] _versionInfoGetActions = new[]
            {
                new Tuple<string, Func<VersionInfoService, VersionInfo>>("Delegate", 
                                                                         (service) =>
                                                                             {
                                                                                 VersionInfo received = null;
                                                                                 service.Get(null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                                                                                 return received;
                                                                             }),
                new Tuple<string, Func<VersionInfoService, VersionInfo>>("Sync", 
                                                                         (service) =>
                                                                             {
                                                                                 return service.Get(null);
                                                                             }),
                new Tuple<string, Func<VersionInfoService, VersionInfo>>("Async", 
                                                                         (service) =>
                                                                             {
                                                                                 return service.GetAsync(null).Result;
                                                                             })
            };

        [Test]
        public void WeGetCompanyFileWithResourcesUsingCompanyFileBaseUrl([ValueSource("_versionInfoGetActions")] Tuple<string, Func<VersionInfoService, VersionInfo>> action)
        {
            // arrange
            var vi = new VersionInfo() { Build = "1.2.3-alpha", Resources = new[] { new VersionMap() { ResourcePath = "/Alpha/" } } };
            _webFactory.RegisterResultForUri(new Uri("https://api.myob.com/accountright/info").AbsoluteUri, vi.ToJson());

            // act
            var received = action.Item2(_service);

            // assert
            Assert.AreEqual(vi.Build, received.Build);
        }

    }
}