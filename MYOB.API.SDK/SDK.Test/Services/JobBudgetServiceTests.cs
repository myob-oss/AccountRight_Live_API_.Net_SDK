using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class JobBudgetServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/JobBudget", new JobBudgetService(null, null).Route);
        }
    }
}