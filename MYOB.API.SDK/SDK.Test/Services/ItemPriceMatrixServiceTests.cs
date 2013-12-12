using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Inventory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ItemPriceMatrixServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Inventory/ItemPriceMatrix", new ItemPriceMatrixService(null, null).Route);
        }
    }
}