using MYOB.AccountRight.SDK.Services.Banking;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class SpendMoneyTxnServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Banking/SpendMoneyTxn", new SpendMoneyTxnService(null).Route);
        }
    }
}