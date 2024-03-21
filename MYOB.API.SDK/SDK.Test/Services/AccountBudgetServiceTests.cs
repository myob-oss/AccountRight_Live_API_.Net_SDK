using System;
using System.Net;
using System.Threading;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Payroll;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class AccountBudgetServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new AccountBudgetService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _financialYear = 2014;
            _cf = new CompanyFile
                {
                    Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10")
                };
            _getRangeUri = string.Format("{0}/{1}/?", _cf.Uri.AbsoluteUri, _service.Route);
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private AccountBudgetService _service;
        private static int _financialYear;
        private CompanyFile _cf;
        private string _getRangeUri;

        [Test]
        public void GetAsync_WhenIdAndCancellationTokenIsPassedIn_ReturnsEntity()
        {
            // Arrange

            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear),
                new AccountBudget().ToJson());

            // Act, Assert  
            var result = _service.GetAsync(_cf, _financialYear, null, new CancellationToken()).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAsync_WhenIdIsPassedIn_ReturnsEntity()
        {
            // Arrange
            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear),
                new AccountBudget().ToJson());

            // Act, Assert  
            var result = _service.GetAsync(_cf, _financialYear, null).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAsync_WhenUriAndCancellationTokenPassedIn_ReturnsEntity()
        {
            // Arrange
            string uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear);
            _webFactory.RegisterResultForUri(uri, new Timesheet().ToJson());

            // Act, Assert  
            var result = _service.GetAsync(_cf, new Uri(uri), null, new CancellationToken()).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAsync_WhenUriPassedIn_ReturnsEntity()
        {
            // Arrange
            string uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear);
            _webFactory.RegisterResultForUri(uri, new Timesheet().ToJson());

            // Act, Assert  
            var result = _service.GetAsync(_cf, new Uri(uri), null).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WhenNoStartDate_ReturnsEntity()
        {
            // Arrange
            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear), new Timesheet().ToJson());

            // Act, Assert  
            var result = _service.Get(_cf, _financialYear, null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWithDelegate_ReturnsEntity()
        {
            // Arrange
            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear),
                new AccountBudget().ToJson());

            // Act, Assert  
            _service.Get(_cf, _financialYear, null,
                         (code, accountbudget) => Assert.IsNotNull(accountbudget),
                         (uri, exception) => Assert.Fail(exception.Message));
        }

        [Test]
        public void GetWithDelegate_WhenGetItemByIdAndUriPassedIn_ReturnsEntity()
        {
            // Arrange
            var uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear);
            _webFactory.RegisterResultForUri(uri, new AccountBudget().ToJson());

            // Act, Assert  
            _service.Get(_cf, new Uri(uri), null,
                         (code, accountbudget) => Assert.IsNotNull(accountbudget),
                         (url, exception) => Assert.Fail(exception.Message));
        }

        [Test]
        public void Get_WhenNoDateRange_NoDateRangeQueryStringIsBuilt()
        {
            // Arrange
            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear), new AccountBudget().ToJson());

            // Act, Assert  
            var result = _service.Get(_cf, _financialYear, null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WhenUriPassedIn_NoDateRangeQueryStringIsBuilt()
        {
            // Arrange
            var uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _financialYear);
            _webFactory.RegisterResultForUri(
                uri, new AccountBudget().ToJson());

            // Act, Assert  
            var result = _service.Get(_cf, new Uri(uri), null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WhenCompanyFileUIDIsDifferentThanUrilCFUID_ThrowsException()
        {
            // Arrange
            var uri = string.Format("{0}/{1}/{2}", "https://dc1.api.myob.com/accountright/00000000-AF68-4C5B-844A-3F054E00DF10", _service.Route, _financialYear);
            _webFactory.RegisterResultForUri(
                uri, new AccountBudget().ToJson());

            _cf.Id = Guid.NewGuid();

            // Act, Assert  
            Assert.Throws<ArgumentException>(() => _service.Get(_cf, new Uri(uri), null));
        }

        [Test]
        public void GetRange_WhenSync_ReturnsEntityItems()
        {
            // Arrange
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<AccountBudget> { Items = new[] { new AccountBudget(), } }).ToJson());

            // Act
            var result = _service.GetRange(_cf, new Uri(_getRangeUri).Query, null);

            // Assert            
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Items.Length);
        }

        [Test]
        public void GetRange_WhenAsyncWithDelegates_ReturnsEntityItems()
        {
            // Arrange
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<AccountBudget> { Items = new[] { new AccountBudget(), } }).ToJson());
            bool completed = false; 

            // Act
            _service.GetRange(_cf, new Uri(_getRangeUri).Query, null, (code, result) =>
                { 
                    completed = true;
                    Assert.IsNotNull(result);
                    Assert.AreEqual(1, result.Items.Length);
                }, (url, ex) => Assert.Fail(ex.ToString()));

            // Assert            
            Assert.IsTrue(completed);
        }

        [Test]
        public void GetRangeAsync_WhenCancellationToken_ReturnsEntityItems()
        {
            // Arrange
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<AccountBudget> { Items = new[] { new AccountBudget(), } }).ToJson());

            // Act
            var result = _service.GetRangeAsync(_cf, new Uri(_getRangeUri).Query, null, new CancellationToken()).Result;

            // Assert            
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Items.Length);
        }

        [Test]
        public void GetRangeAsync_WhenNoCancellationToken_ReturnsEntityItems()
        {
            // Arrange
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<AccountBudget> { Items = new[] { new AccountBudget(), } }).ToJson());

            // Act
            var result = _service.GetRangeAsync(_cf, new Uri(_getRangeUri).Query, null).Result;

            // Assert            
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Items.Length);
        }

        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/AccountBudget", new AccountBudgetService(null).Route);
        }

        private static readonly Tuple<string, Func<AccountBudgetService, CompanyFile, string>>[] _putActions = new[]
            {
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new AccountBudget() { FinancialYear = _financialYear }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new AccountBudget() { FinancialYear = _financialYear }, null);
                    }),
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new AccountBudget() { FinancialYear = _financialYear }, null).Result;
                    }),
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Async1", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new AccountBudget() { FinancialYear = _financialYear }, null, CancellationToken.None).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl([ValueSource("_putActions")] Tuple<string, Func<AccountBudgetService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/" + new AccountBudgetService(null).Route + "/" + _financialYear;
            _webFactory.RegisterResultForUri(location, (string)null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }

        private static readonly Tuple<string, Func<AccountBudgetService, CompanyFile, string>>[] _putActionsWarnings = new[]
            {
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new AccountBudget() { FinancialYear = _financialYear }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message), ErrorLevel.WarningsAsErrors);
                        return received;
                    }),
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new AccountBudget() { FinancialYear = _financialYear }, null, ErrorLevel.WarningsAsErrors);
                    }),
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new AccountBudget() { FinancialYear = _financialYear }, null, ErrorLevel.WarningsAsErrors).Result;
                    }),
                new Tuple<string, Func<AccountBudgetService, CompanyFile, string>>("Async1", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new AccountBudget() { FinancialYear = _financialYear }, null, CancellationToken.None, ErrorLevel.WarningsAsErrors).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl_WarningsAsErrors([ValueSource("_putActionsWarnings")] Tuple<string, Func<AccountBudgetService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/" + new AccountBudgetService(null).Route + "/" + _financialYear;
            _webFactory.RegisterResultForUri(location + "/?warningsAsErrors=true", (string)null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", received);
        }
    }
}