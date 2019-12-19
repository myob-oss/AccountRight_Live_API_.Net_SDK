using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class SaleInvoiceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/{Quote|Invoice}|{Service|Item|Professional|TimeBilling|Miscellaneous}/Email", new SaleEmailService(null, null).Route);
        }
    }
}