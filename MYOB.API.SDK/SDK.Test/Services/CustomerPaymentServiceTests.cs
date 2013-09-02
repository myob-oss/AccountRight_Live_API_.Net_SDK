using System;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

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
}