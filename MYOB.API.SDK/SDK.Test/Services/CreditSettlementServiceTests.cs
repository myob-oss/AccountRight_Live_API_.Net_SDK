using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CreditSettlementServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/CreditSettlement", new CreditSettlementService(null).Route);
        }
    }
}