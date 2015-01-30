using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services.Payroll;
using NSubstitute;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace SDK.Test.Services
{
    public class TimesheetServicePacTests : IUseFixture<MyobArlApiPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        private IApiConfiguration _configuration;
        private TimesheetService _service;
        private CompanyFile _cf;
        private Guid _cfUid;
        private Guid _uid;

        public void SetFixture(MyobArlApiPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
            _mockProviderService.ClearInteractions(); //NOTE: Clears any previously registered interactions before the test is run

            _configuration = Substitute.For<IApiConfiguration>();
            _service = new TimesheetService(_configuration, keyService: new SimpleOAuthKeyService());

            _cfUid = Guid.NewGuid();
            _uid = Guid.NewGuid(); 

            _cf = new CompanyFile
                {
                    Uri = new Uri(string.Format("{0}/accountright/{1}", _mockProviderServiceBaseUri, _cfUid))
                };
        }

        [Fact]
        public void GetAsync_WhenIdAndCancellationTokenIsPassedIn_ReturnsEntity()
        {
            // arrange
            DateTime? startDate = new DateTime(2014, 10, 22);
            DateTime? endDate = new DateTime(2014, 10, 29);

            _mockProviderService
                .Given(string.Format("Given I have Timesheet data for the date range {0} to {1}", startDate, endDate))
                .UponReceiving(string.Format("A GET request for Timesheet data for the daternage {0} to {1}", startDate, endDate))
                .With(new ProviderServiceRequest
                    {
                        Method = HttpVerb.Get,
                        Path = string.Format("/accountright/{0}/{1}/{2}",
                                             _cfUid,
                                             _service.Route,
                                             _uid),
                        Headers = new Dictionary<string, string>
                            {
                                {"Authorization", "Bearer"},
                                {"Accept-Encoding", "gzip"},
                                {"User-Agent", ApiRequestHelper.UserAgent},
                                {"x-myobapi-key", ""},
                                {"x-myobapi-version", "v2"},
                                {"x-myobapi-cftoken", Convert.ToBase64String(Encoding.UTF8.GetBytes(":"))},
                            },
                        Query = string.Format("StartDate={0}&EndDate={1}",
                                              startDate.Value.Date.ToString("s"),
                                              endDate.Value.Date.ToString("s"))
                    })
                .WillRespondWith(new ProviderServiceResponse
                    {
                        Status = 200,
                        Headers = new Dictionary<string, string>
                            {
                                {"Content-Type", "application/json; charset=utf-8"}
                            },
                        Body =
                            new //NOTE: Note the case sensitivity here, the body will be serialised as per the casing defined
                                {
                                    StartDate = startDate.Value.Date.ToString("s"),
                                    EndDate = endDate.Value.Date.ToString("s")
                                }
                    });

            
            // act
            var result = _service.GetAsync(_cf, _uid, startDate.Value, endDate.Value, null, new CancellationToken()).Result;

            // assert
            Assert.NotNull(result);

            _mockProviderService.VerifyInteractions();
        }
    }
}