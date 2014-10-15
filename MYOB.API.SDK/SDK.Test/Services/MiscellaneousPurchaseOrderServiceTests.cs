using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class MiscellaneousPurchaseOrderServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/Order/Miscellaneous", new MiscellaneousPurchaseOrderService(null, null).Route);
        }
    }
}