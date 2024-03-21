using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        public void LocationIsCreatedWithDefaultValues()
        {
            var location = new Location();

            Assert.IsTrue(location.IsActive);
        }
    }
}
