using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ItemPurchaseOrderServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/Order/Item", new ItemPurchaseOrderService(null, null).Route);
        }
    }
}