using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using MYOB.AccountRight.SDK.Extensions;

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

        private static readonly Tuple<string, Func<VersionInfoService, VersionInfo>>[] _versionInfoGetActions = new[]
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


    [TestFixture]
    public class CompanyFileServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private CompanyFileService _service;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new CompanyFileService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }

        private static readonly Tuple<string, Func<CompanyFileService, CompanyFile[]>>[] _companyFileActions = new[]
            {
                new Tuple<string, Func<CompanyFileService, CompanyFile[]>>("Delegate", 
                    service =>
                    {
                        CompanyFile[] received = null;
                        service.GetRange((code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<CompanyFileService, CompanyFile[]>>("Sync", 
                    service =>
                    {
                        return service.GetRange();
                    }),
                new Tuple<string, Func<CompanyFileService, CompanyFile[]>>("Async", 
                    service =>
                    {
                        return service.GetRangeAsync().Result;
                    }),
            };

        [Test]
        public void WeGetCompanyFilesUsingTheConfigurationSuppliedBaseUrl([ValueSource("_companyFileActions")] Tuple<string, Func<CompanyFileService, CompanyFile[]>> action)
        {
            // arrange
            var id = Guid.NewGuid();
            _webFactory.RegisterResultForUri(ApiRequestHandler.ApiRequestUri.AbsoluteUri, new[] { new CompanyFile { Id = id } }.ToJson());

            // act
            var received = action.Item2(_service);

            // assert
            Assert.AreEqual(1, received.Count());
            Assert.AreEqual(id, received[0].Id);

        }

        private static readonly Tuple<string, Func<CompanyFileService, CompanyFile, CompanyFileWithResources>>[] _companyFileWithResourceActions = new[]
            {
                new Tuple<string, Func<CompanyFileService, CompanyFile, CompanyFileWithResources>>("Delegate", 
                    (service, cf) =>
                    {
                        CompanyFileWithResources received = null;
                        service.Get(cf, null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<CompanyFileService, CompanyFile, CompanyFileWithResources>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Get(cf, null);
                    }),
                new Tuple<string, Func<CompanyFileService, CompanyFile, CompanyFileWithResources>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, null).Result;
                    })
            };

        [Test]
        public void WeGetCompanyFileWithResourcesUsingCompanyFileBaseUrl([ValueSource("_companyFileWithResourceActions")] Tuple<string, Func<CompanyFileService, CompanyFile, CompanyFileWithResources>> action)
        {
            // arrange
            var id = Guid.NewGuid();
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri, new CompanyFileWithResources() { CompanyFile = new CompanyFile() { Id = id } }.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(id, received.CompanyFile.Id);
        }

        private static readonly Tuple<string, Func<CompanyFileService, CompanyFile[]>>[] _getRangeQueryActions = new[]
            {
                new Tuple<string, Func<CompanyFileService, CompanyFile[]>>("Delegate", 
                    (service) =>
                    {
                        CompanyFile[] received = null;
                        service.GetRange("$filter=Id eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'", (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<CompanyFileService, CompanyFile[]>>("Sync", 
                    (service) =>
                    {
                        return service.GetRange("$filter=Id eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'");
                    }),
                new Tuple<string, Func<CompanyFileService, CompanyFile[]>>("Sync", 
                    (service) =>
                    {
                        return service.GetRangeAsync("$filter=Id eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'").Result;
                    })
            };

        [Test]
        public void WeGetRangeUsingCompanyFileBaseUrlAndQuery([ValueSource("_getRangeQueryActions")] Tuple<string, Func<CompanyFileService, CompanyFile[]>> action)
        {
            // arrange
            var id = new Guid("2BB63466-1A6C-4757-B3B8-D8B799D641E9");
            _webFactory.RegisterResultForUri(ApiRequestHandler.ApiRequestUri.AbsoluteUri + "/?$filter=Id eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'", new[] { new CompanyFile() { Id = id } }.ToJson());

            // act
            var received = action.Item2(_service);

            // assert
            Assert.AreEqual(id, received[0].Id, "Incorrect data received during {0} operation", action.Item1);
        }
    }
}
