using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollCategorySummaryServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/PayrollCategorySummary", new PayrollCategorySummaryService(null, null).Route);
        }
    }
}