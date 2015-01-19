using MYOB.AccountRight.SDK.Services.Banking;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class TransferMoneyTxnServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Banking/TransferMoneyTxn", new TransferMoneyTxnService(null).Route);
        }
    }
}