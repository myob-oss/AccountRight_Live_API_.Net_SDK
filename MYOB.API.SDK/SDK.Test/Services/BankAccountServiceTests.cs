using MYOB.AccountRight.SDK.Services.Banking;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class BankAccountServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Banking/BankAccount", new BankAccountService(null, null, null).Route);
        }
    }
}