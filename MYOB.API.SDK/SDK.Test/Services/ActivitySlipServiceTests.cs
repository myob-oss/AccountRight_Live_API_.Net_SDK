using MYOB.AccountRight.SDK.Services.TimeBilling;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ActivitySlipServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("TimeBilling/ActivitySlip", new ActivitySlipService(null, null).Route);
        }
    }
}