using MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ActivityTests
    {
        [Test]
        public void AccountIsCreatedWithDefaultValues()
        {
            var account = new Activity();

            Assert.IsTrue(account.IsActive);
        }
    }
}