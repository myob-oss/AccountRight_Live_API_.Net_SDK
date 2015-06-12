using MYOB.AccountRight.SDK.Contracts.Version2.Security;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void UserIsCreatedWithDefaultValues()
        {
            var account = new User();

            Assert.IsTrue(account.IsActive);
        }
    }
}