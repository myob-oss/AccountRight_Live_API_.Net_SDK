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
    public class SupplierPaymentRecordWithDiscountsAndFeesServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private SupplierPaymentRecordWithDiscountsAndFeesService _service;
        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new SupplierPaymentRecordWithDiscountsAndFeesService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/SupplierPayment/RecordWithDiscountsAndFees", new SupplierPaymentRecordWithDiscountsAndFeesService(null, null).Route);
        }

        private readonly Tuple<string, Func<SupplierPaymentRecordWithDiscountsAndFeesService, CompanyFile, SupplierPaymentRecordWithDiscountsAndFeesResponse>>[] _executeActions =
        {
            new Tuple<string, Func<SupplierPaymentRecordWithDiscountsAndFeesService, CompanyFile, SupplierPaymentRecordWithDiscountsAndFeesResponse>>("ExecuteDelegate", 
                (service, cf) =>
                {
                    SupplierPaymentRecordWithDiscountsAndFeesResponse responseEntity = null;
                    service.Execute(cf, new SupplierPaymentRecordWithDiscountsAndFees(), null, (code, location, response) => { responseEntity = response; }, (uri, exception) => Assert.Fail(exception.Message));
                    return responseEntity;
                }),
            new Tuple<string, Func<SupplierPaymentRecordWithDiscountsAndFeesService, CompanyFile, SupplierPaymentRecordWithDiscountsAndFeesResponse>>("ExecuteSync", 
                (service, cf) => service.Execute(cf, new SupplierPaymentRecordWithDiscountsAndFees(), null)),
            new Tuple<string, Func<SupplierPaymentRecordWithDiscountsAndFeesService, CompanyFile, SupplierPaymentRecordWithDiscountsAndFeesResponse>>("ExecuteAsync", 
                (service, cf) => service.ExecuteAsync(cf, new SupplierPaymentRecordWithDiscountsAndFees(), null).Result)
        };

        [Test]
        public void WeExecuteOperationUsingCompanyFileBaseUrl([ValueSource("_executeActions")] Tuple<string, Func<SupplierPaymentRecordWithDiscountsAndFeesService, CompanyFile, SupplierPaymentRecordWithDiscountsAndFeesResponse>> action)
        {
            // arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };

            var location = cf.Uri.AbsoluteUri + "/" + _service.Route;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/" + _service.Route, new SupplierPaymentRecordWithDiscountsAndFeesResponse() { }.ToJson(), HttpStatusCode.OK);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(received);
        }
    }
}
