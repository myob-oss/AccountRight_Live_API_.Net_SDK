using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class BalanceSheetSummaryServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/BalanceSheetSummary", new BalanceSheetSummaryService(null).Route);
        }
    }
}