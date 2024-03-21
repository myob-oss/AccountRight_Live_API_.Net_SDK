using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Company;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services.Company;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using System;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CompanyPreferencesServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private CompanyPreferencesService _service;
        private CompanyFile _cf;
        private string _getRangeUri;

        public static readonly object[] CompanySystemPreferencesData =
        {
            new object[] { CategoryTracking.Off, true, new DateTime(2018,7,1), true },
            new object[] { CategoryTracking.OnAndNotRequired, false, null, false },
            new object[] { CategoryTracking.OnAndRequired, true, null, true }
        };

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new CompanyPreferencesService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            
            _cf = new CompanyFile
            {
                Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10")
            };
            _getRangeUri = string.Format("{0}/{1}/", _cf.Uri.AbsoluteUri, _service.Route);
        }

        [Test, TestCaseSource("CompanySystemPreferencesData")]
        public void Get_CompanySystemPreferences(CategoryTracking categoryTracking, bool transactionsCannotBeChangedMustBeReversed, DateTime? lockPeriodPriorTo, bool useAlphaAccountIdentifier)
        {
            // Arrange
            var companySystemPreferences = new CompanySystemPreferences()
            {
                CategoryTracking = categoryTracking,
                TransactionsCannotBeChangedMustBeReversed = transactionsCannotBeChangedMustBeReversed,
                LockPeriodPriorTo = lockPeriodPriorTo,
                UseAlphaAccountIdentifier = useAlphaAccountIdentifier
            };

            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/", _cf.Uri.AbsoluteUri, _service.Route), new CompanyPreferences() { System = companySystemPreferences }.ToJson());

            // Act
            var result = _service.Get(_cf, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryTracking, result.System.CategoryTracking);
            Assert.AreEqual(transactionsCannotBeChangedMustBeReversed, result.System.TransactionsCannotBeChangedMustBeReversed);
            Assert.AreEqual(lockPeriodPriorTo, result.System.LockPeriodPriorTo);
            Assert.AreEqual(companySystemPreferences.UseAlphaAccountIdentifier, result.System.UseAlphaAccountIdentifier);
        }

        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company/Preferences", new CompanyPreferencesService(null).Route);
        }
    }
}
