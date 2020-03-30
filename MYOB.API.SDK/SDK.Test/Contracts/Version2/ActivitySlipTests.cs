using MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ActivitySlipTests
    {
        [Test]
        public void ActivitySlipIsCreatedWithDefaultValues()
        {
            var activitySlip = new ActivitySlip();

            Assert.AreEqual(activitySlip.UnitCount, null);
        }
    }
}