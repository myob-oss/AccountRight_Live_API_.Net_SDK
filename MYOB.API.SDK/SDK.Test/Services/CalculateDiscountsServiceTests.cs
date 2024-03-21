using System;
using System.Net;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services.Purchase;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CalculateDiscountsServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private CalculateDiscountsService _service;
        
        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new CalculateDiscountsService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }

        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/SupplierPayment/CalculateDiscounts", _service.Route);
        }
        
        private static readonly Tuple<string, Func<CalculateDiscountsService, CompanyFile, CalculateDiscountsResponse>>[] _executeActions =
        {
            new Tuple<string, Func<CalculateDiscountsService, CompanyFile, CalculateDiscountsResponse>>("ExecuteDelegate", 
                (service, cf) =>
                {
                    CalculateDiscountsResponse responseEntity = null;
                    service.Execute(cf, new CalculateDiscounts(), null, (code, location, response) => { responseEntity=response; }, (uri, exception) => Assert.Fail(exception.Message));
                    return responseEntity;
                }),
            new Tuple<string, Func<CalculateDiscountsService, CompanyFile, CalculateDiscountsResponse>>("ExecuteSync", 
                (service, cf) => service.Execute(cf, new CalculateDiscounts(), null)),
            new Tuple<string, Func<CalculateDiscountsService, CompanyFile, CalculateDiscountsResponse>>("ExecuteAsync", 
                (service, cf) => service.ExecuteAsync(cf, new CalculateDiscounts(), null).Result)
        };
        
        [Test]
        public void WePostCalculateDiscountsUsingCompanyFileBaseUrl([ValueSource("_executeActions")] Tuple<string, Func<CalculateDiscountsService, CompanyFile, CalculateDiscountsResponse>> action)
        {
            // arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };

            var location = cf.Uri.AbsoluteUri + "/" + _service.Route;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/" + _service.Route, new CalculateDiscounts().ToJson(), HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(received);
        }
    }
}
