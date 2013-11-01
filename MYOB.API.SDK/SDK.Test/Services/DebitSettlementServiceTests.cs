using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class DebitSettlementServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/DebitSettlement", new DebitSettlementService(null).Route);
        }
    }
}