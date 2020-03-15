using MYOB.AccountRight.SDK.Services.Inventory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class LocationServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Inventory/Location", new LocationService(null).Route);
        }
    }
}
