using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ProfitAndLossSummaryServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/ProfitAndLossSummary", new ProfitAndLossSummaryService(null).Route);
        }
    }
}