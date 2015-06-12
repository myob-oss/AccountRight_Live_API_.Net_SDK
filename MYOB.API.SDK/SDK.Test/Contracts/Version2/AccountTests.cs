using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void AccountIsCreatedWithDefaultValues()
        {
            var account = new Account();

            Assert.IsTrue(account.IsActive);
        }
    }
}
