using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/Account", new AccountService(null, null).Route);
        }
    }
}