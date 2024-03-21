using System;
using System.Net;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using MYOB.AccountRight.SDK.Services.Sale;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using MYOB.AccountRight.SDK.Extensions;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CustomerPaymentServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/CustomerPayment", new CustomerPaymentService(null, null).Route);
        }

        [Test]
        public void PutSyncIsNotSupported()
        {
            var service = new CustomerPaymentService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Update(null, null, null));
        }

        [Test]
        public void PutDelegateIsNotSupported()
        {
            var service = new CustomerPaymentService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Update(null, null, null, (code, s) => {}, (uri, exception) => {}));
        }

        [Test]
        public void PutAsyncIsNotSupported()
        {
            var service = new CustomerPaymentService(null, null);

            var ex = Assert.Throws<AggregateException>(() => service.UpdateAsync(null, null, null).Wait());
            Assert.IsInstanceOf<NotSupportedException>(ex.InnerException);
        }
    }

    [TestFixture]
    public class CustomerPaymentRecordWithDiscountsAndFeesServiceTests
    {
        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private CustomerPaymentRecordWithDiscountsAndFeesService _service;
        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new CustomerPaymentRecordWithDiscountsAndFeesService(_configuration, _webFactory);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
        }

        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/CustomerPayment/RecordWithDiscountsAndFees", _service.Route);
        }

        private static readonly Tuple<string, Func<CustomerPaymentRecordWithDiscountsAndFeesService, CompanyFile, CustomerPaymentRecordWithDiscountsAndFeesResponse>>[] _executeActions =
        {
            new Tuple<string, Func<CustomerPaymentRecordWithDiscountsAndFeesService, CompanyFile, CustomerPaymentRecordWithDiscountsAndFeesResponse>>("ExecuteDelegate", 
                (service, cf) =>
                {
                    CustomerPaymentRecordWithDiscountsAndFeesResponse responseEntity = null;
                    service.Execute(cf, new CustomerPaymentRecordWithDiscountsAndFees(), null, (code, location, response) => { responseEntity = response; }, (uri, exception) => Assert.Fail(exception.Message));
                    return responseEntity;
                }),
            new Tuple<string, Func<CustomerPaymentRecordWithDiscountsAndFeesService, CompanyFile, CustomerPaymentRecordWithDiscountsAndFeesResponse>>("ExecuteSync", 
                (service, cf) => service.Execute(cf, new CustomerPaymentRecordWithDiscountsAndFees(), null)),
            new Tuple<string, Func<CustomerPaymentRecordWithDiscountsAndFeesService, CompanyFile, CustomerPaymentRecordWithDiscountsAndFeesResponse>>("ExecuteAsync", 
                (service, cf) => service.ExecuteAsync(cf, new CustomerPaymentRecordWithDiscountsAndFees(), null).Result)
        };

        [Test]
        public void WeExecuteOperationUsingCompanyFileBaseUrl([ValueSource("_executeActions")] Tuple<string, Func<CustomerPaymentRecordWithDiscountsAndFeesService, CompanyFile, CustomerPaymentRecordWithDiscountsAndFeesResponse>> action)
        {
            // arrange
            var cf = new CompanyFile { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };

            var location = cf.Uri.AbsoluteUri + "/" + _service.Route;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/" + _service.Route, new CustomerPaymentRecordWithDiscountsAndFeesResponse(){}.ToJson(), HttpStatusCode.OK);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(received);
        }
    }
}