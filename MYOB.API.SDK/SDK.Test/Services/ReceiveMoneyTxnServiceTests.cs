using MYOB.AccountRight.SDK.Services.Banking;
using NUnit.Framework;

namespace SDK.Test.Services
{
    public class ReceiveMoneyTxnServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Banking/ReceiveMoneyTxn", new ReceiveMoneyTxnService(null).Route);
        }
    }
}
