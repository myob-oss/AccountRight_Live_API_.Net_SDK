using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class TimeBillingInvoiceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Invoice/TimeBilling", new TimeBillingInvoiceService(null, null).Route);
        }
    }
}