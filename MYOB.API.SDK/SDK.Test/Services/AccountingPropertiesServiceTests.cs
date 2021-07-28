using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using MYOB.AccountRight.SDK.Extensions;

namespace SDK.Test.Services
{
    [TestFixture]
    public class AccountingPropertiesServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private AccountingPropertiesService _service;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new AccountingPropertiesService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }

        private static readonly Tuple<string, Func<AccountingPropertiesService, CompanyFile, AccountingProperties>>[] _getAccountingPropertiesActions = new[]
            {
                new Tuple<string, Func<AccountingPropertiesService, CompanyFile, AccountingProperties>>("Delegate", 
                    (service, cf) =>
                    {
                        AccountingProperties received = null;
                        service.Get(cf, Guid.Empty, null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<AccountingPropertiesService, CompanyFile, AccountingProperties>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Get(cf, Guid.Empty, null);
                    }),
                new Tuple<string, Func<AccountingPropertiesService, CompanyFile, AccountingProperties>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, Guid.Empty, null).Result;
                    }),
            };

        [Test]
        public void WeGetAccountingPropertiesUsingCompanyFileBaseUrl([ValueSource("_getAccountingPropertiesActions")] Tuple<string, Func<AccountingPropertiesService, CompanyFile, AccountingProperties>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/GeneralLedger/AccountingProperties", new PagedCollection<AccountingProperties>() { Items = new[] { new AccountingProperties { ConversionDate = DateTime.Parse("01/01/2013") } }, Count = 1 }.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(DateTime.Parse("01/01/2013"), received.ConversionDate);
        }


        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/AccountingProperties", new AccountingPropertiesService(null, null).Route);
        }
    }
}
