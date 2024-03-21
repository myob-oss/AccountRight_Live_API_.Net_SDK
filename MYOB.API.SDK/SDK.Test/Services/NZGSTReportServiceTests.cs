using MYOB.AccountRight.SDK.Services.Report.GST;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class NZGSTReportServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/GST/NZGSTReport", new NZGSTReportService(null, null).Route);
        }
    }
}