using System;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Company;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services.Company;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CompanyPreferencesServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private CompanyPreferencesService _service;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new CompanyPreferencesService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company/Preferences", new CompanyPreferencesService(null).Route);
        }
        private readonly Tuple<string, Func<CompanyPreferencesService, CompanyFile, CompanyPreferences>>[] _getActions =
        {
            new Tuple<string, Func<CompanyPreferencesService, CompanyFile, CompanyPreferences>>("GetDelegate", 
                (service, cf) =>
                {
                    CompanyPreferences received = null;
                    service.Get(cf, null, (code, data) => { received = data; }, (uri, exception) => Assert.Fail(exception.Message));
                    return received;
                }),
            new Tuple<string, Func<CompanyPreferencesService, CompanyFile, CompanyPreferences>>("GetSync", 
                (service, cf) => service.Get(cf, null)),
            new Tuple<string, Func<CompanyPreferencesService, CompanyFile, CompanyPreferences>>("GetAsync", 
                (service, cf) => service.GetAsync(cf, null).Result)
        };
        [Test]
        public void WeGetCompanyPreferencesUsingCompanyFileBaseUrl([ValueSource("_getActions")] Tuple<string, Func<CompanyPreferencesService, CompanyFile, CompanyPreferences>> action)
        {
            // arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var companyPreferences = new CompanyPreferences
                {
                    System = new CompanySystemPreferences
                    {
                        CategoryTracking = CategoryTracking.OnAndNotRequired,
                        LockPeriodPriorTo = new DateTime(2013, 7, 1),
                        TransactionsCannotBeChangedMustBeReversed = true
                    }
                };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Company/Preferences", companyPreferences.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(companyPreferences.System.CategoryTracking, received.System.CategoryTracking, "Incorrect data received during {0} operation", action.Item1);
            Assert.AreEqual(companyPreferences.System.LockPeriodPriorTo, received.System.LockPeriodPriorTo, "Incorrect data received during {0} operation", action.Item1);
            Assert.AreEqual(companyPreferences.System.TransactionsCannotBeChangedMustBeReversed, received.System.TransactionsCannotBeChangedMustBeReversed, "Incorrect data received during {0} operation", action.Item1);
        }
    }
}
