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
    public class CompanyServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private CompanyService _service;
   
        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new CompanyService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }

        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company", new CompanyService(null, null).Route);
        }

        private readonly Tuple<string, Func<CompanyService, CompanyFile, Company>>[] _companyInfoGetActions = new[]
            {
                new Tuple<string, Func<CompanyService, CompanyFile, Company>>("Delegate", 
                    (service, cf) =>
                    {
                        Company received = null;
                        service.Get(cf, null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<CompanyService, CompanyFile, Company>>("Sync", 
                    (service, cf) => service.Get(cf, null)),
                new Tuple<string, Func<CompanyService, CompanyFile, Company>>("Async", 
                    (service, cf) => service.GetAsync(cf, null).Result)
            };


        [Test]
        public void GetCompanyUsingCompanyFileBaseUrl([ValueSource("_companyInfoGetActions")] Tuple<string, Func<CompanyService, CompanyFile, Company>> action)
        {
            //arrange
            var company = new Company { CompanyName = "My Company" };
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/company", company.ToJson());
            
            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(company.CompanyName, received.CompanyName);
        }

    }
}
