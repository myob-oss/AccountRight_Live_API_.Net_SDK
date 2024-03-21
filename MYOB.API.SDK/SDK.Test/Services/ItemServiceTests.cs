using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Inventory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ItemServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Inventory/Item", new ItemService(null, null).Route);
        }
    }
}