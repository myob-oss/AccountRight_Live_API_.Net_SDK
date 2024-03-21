using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class TaxCodeSummaryServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/TaxCodeSummary", new TaxCodeSummaryService(null, null).Route);
        }
    }
}