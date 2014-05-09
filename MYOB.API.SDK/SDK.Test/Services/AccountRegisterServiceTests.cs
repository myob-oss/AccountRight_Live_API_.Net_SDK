using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class AccountRegisterServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/AccountRegister", new AccountRegisterService(null, null).Route);
        }
    }
}