using MYOB.AccountRight.SDK.Services.Inventory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class InventoryAdjustmentServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Inventory/Adjustment", new InventoryAdjustmentService(null, null).Route);
        }
    }
}