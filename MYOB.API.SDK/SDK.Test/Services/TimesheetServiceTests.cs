using System;
using System.Net;
using System.Threading;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.Payroll;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Payroll;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class TimesheetServiceTests 
    {
        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new TimesheetService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _newGuid = Guid.NewGuid();
            _cf = new CompanyFile
                {
                    Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10")
                };
            _getRangeUri = string.Format("{0}/{1}/?StartDate={2}&EndDate={3}", _cf.Uri.AbsoluteUri,
                                         _service.Route, ((DateTime?)new DateTime(2014, 10, 22)).Value.Date.ToString("s"), ((DateTime?)new DateTime(2014, 10, 29)).Value.Date.ToString("s"));
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private TimesheetService _service;
        private static Guid _newGuid;
        private CompanyFile _cf;
        private string _getRangeUri;
        private static readonly Guid Uid = Guid.NewGuid();

        [Test]
        public void GetAsync_WhenIdAndCancellationTokenIsPassedIn_ReturnsEntity()
        {
            // Arrange
            DateTime? startDate = new DateTime(2014, 10, 22);
            DateTime? endDate = new DateTime(2014, 10, 29);

            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}?StartDate={3}&EndDate={4}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid,
                              startDate.Value.Date.ToString("s"), endDate.Value.Date.ToString("s")),
                new Timesheet().ToJson());

            // Act, Assert  
            Timesheet result =
                _service.GetAsync(_cf, _newGuid, startDate.Value, endDate.Value, null, new CancellationToken()).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAsync_WhenIdIsPassedIn_ReturnsEntity()
        {
            // Arrange
            DateTime? startDate = new DateTime(2014, 10, 22);
            DateTime? endDate = new DateTime(2014, 10, 29);

            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}?StartDate={3}&EndDate={4}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid,
                              startDate.Value.Date.ToString("s"), endDate.Value.Date.ToString("s")),
                new Timesheet().ToJson());

            // Act, Assert  
            Timesheet result = _service.GetAsync(_cf, _newGuid, startDate.Value, endDate.Value, null).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAsync_WhenUriAndCancellationTokenPassedIn_ReturnsEntity()
        {
            // Arrange
            string uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid);
            _webFactory.RegisterResultForUri(uri, new Timesheet().ToJson());

            // Act, Assert  
            Timesheet result = _service.GetAsync(_cf, new Uri(uri), null, new CancellationToken()).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAsync_WhenUriPassedIn_ReturnsEntity()
        {
            // Arrange
            string uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid);
            _webFactory.RegisterResultForUri(uri, new Timesheet().ToJson());

            // Act, Assert  
            Timesheet result = _service.GetAsync(_cf, new Uri(uri), null).Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WhenNoStartDate_ReturnsEntity()
        {
            // Arrange
            DateTime? endDate = new DateTime(2014, 10, 29);
            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}?EndDate={3}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid,
                              endDate.Value.Date.ToString("s")), new Timesheet().ToJson());

            // Act, Assert  
            Timesheet result = _service.Get(_cf, _newGuid, null, endDate, null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWithDelegate_ReturnsEntity()
        {
            // Arrange
            DateTime? startDate = new DateTime(2014, 10, 22);
            DateTime? endDate = new DateTime(2014, 10, 29);

            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}?StartDate={3}&EndDate={4}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid,
                              startDate.Value.Date.ToString("s"), endDate.Value.Date.ToString("s")),
                new Timesheet().ToJson());

            // Act, Assert  
            _service.Get(_cf, _newGuid, startDate.Value, endDate.Value, null,
                         (code, timesheet) => Assert.IsNotNull(timesheet),
                         (uri, exception) => Assert.Fail(exception.Message));
        }

        [Test]
        public void GetWithDelegate_WhenGetItemByIdAndUriPassedIn_ReturnsEntity()
        {
            // Arrange
            DateTime? startDate = new DateTime(2014, 10, 22);
            DateTime? endDate = new DateTime(2014, 10, 29);

            var uri = string.Format("{0}/{1}/{2}?StartDate={3}&EndDate={4}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid, startDate.Value.Date.ToString("s"), endDate.Value.Date.ToString("s"));
            _webFactory.RegisterResultForUri(uri, new Timesheet().ToJson());

            // Act, Assert  
            _service.Get(_cf, new Uri(uri), null,
                         (code, timesheet) => Assert.IsNotNull(timesheet),
                         (url, exception) => Assert.Fail(exception.Message));
        }

        [Test]
        public void Get_WhenNoDateRange_NoDateRangeQueryStringIsBuilt()
        {
            // Arrange
            _webFactory.RegisterResultForUri(
                string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid), new Timesheet().ToJson());

            // Act, Assert  
            var result = _service.Get(_cf, _newGuid, null, null, null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WhenUriPassedIn_NoDateRangeQueryStringIsBuilt()
        {
            // Arrange
            var uri = string.Format("{0}/{1}/{2}", _cf.Uri.AbsoluteUri, _service.Route, _newGuid);
            _webFactory.RegisterResultForUri(
                uri, new Timesheet().ToJson());

            // Act, Assert  
            var result = _service.Get(_cf, new Uri(uri), null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WhenCompanyFileUIDIsDifferentThanUrilCFUID_ThrowsException()
        {
            // Arrange
            var uri = string.Format("{0}/{1}/{2}", "https://dc1.api.myob.com/accountright/00000000-AF68-4C5B-844A-3F054E00DF10", _service.Route, _newGuid);
            _webFactory.RegisterResultForUri(
                uri, new Timesheet().ToJson());

            _cf.Id = Guid.NewGuid();

            // Act, Assert  
            Assert.Throws<ArgumentException>(() => _service.Get(_cf, new Uri(uri), null));
        }

        [Test]
        public void GetRange_WhenSync_ReturnsEntityItems()
        {
            // Arrange
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<Timesheet> { Items = new[] { new Timesheet(), } }).ToJson());

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
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<Timesheet> { Items = new[] { new Timesheet(), } }).ToJson());
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
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<Timesheet> { Items = new[] { new Timesheet(), } }).ToJson());

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
            _webFactory.RegisterResultForUri(_getRangeUri, (new PagedCollection<Timesheet> { Items = new[] { new Timesheet(), } }).ToJson());

            // Act
            var result = _service.GetRangeAsync(_cf, new Uri(_getRangeUri).Query, null).Result;

            // Assert            
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Items.Length);
        }

        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/Timesheet", new TimesheetService(null).Route);
        }

        private static readonly Tuple<string, Func<TimesheetService, CompanyFile, string>>[] _putActions = new[]
            {
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new Timesheet {Employee = new EmployeeLink {UID = Uid} }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new Timesheet { Employee = new EmployeeLink { UID = Uid } }, null);
                    }),
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new Timesheet { Employee = new EmployeeLink { UID = Uid } }, null).Result;
                    }),
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Async1", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new Timesheet { Employee = new EmployeeLink { UID = Uid } }, null, CancellationToken.None).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl([ValueSource("_putActions")] Tuple<string, Func<TimesheetService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Payroll/Timesheet/" + Uid;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Payroll/Timesheet/" + Uid, (string)null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }

        private static readonly Tuple<string, Func<TimesheetService, CompanyFile, string>>[] _putActionsWarnings = new[]
            {
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new Timesheet {Employee = new EmployeeLink {UID = Uid} }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message), ErrorLevel.WarningsAsErrors);
                        return received;
                    }),
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new Timesheet { Employee = new EmployeeLink { UID = Uid } }, null, ErrorLevel.WarningsAsErrors);
                    }),
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new Timesheet { Employee = new EmployeeLink { UID = Uid } }, null, ErrorLevel.WarningsAsErrors).Result;
                    }),
                new Tuple<string, Func<TimesheetService, CompanyFile, string>>("Async1", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new Timesheet { Employee = new EmployeeLink { UID = Uid } }, null, CancellationToken.None, ErrorLevel.WarningsAsErrors).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl_WarningsAsErrors([ValueSource("_putActionsWarnings")] Tuple<string, Func<TimesheetService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Payroll/Timesheet/" + Uid;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Payroll/Timesheet/" + Uid + "?warningsAsErrors=true", (string)null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", received);
        }
    }
}