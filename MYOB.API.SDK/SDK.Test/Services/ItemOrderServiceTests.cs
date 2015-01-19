using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ItemOrderServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Order/Item", new ItemOrderService(null, null).Route);
        }
    }
}