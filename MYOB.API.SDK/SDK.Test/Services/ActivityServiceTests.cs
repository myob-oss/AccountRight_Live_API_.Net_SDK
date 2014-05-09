using MYOB.AccountRight.SDK.Services.TimeBilling;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ActivityServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("TimeBilling/Activity", new ActivityService(null, null).Route);
        }
    }
}