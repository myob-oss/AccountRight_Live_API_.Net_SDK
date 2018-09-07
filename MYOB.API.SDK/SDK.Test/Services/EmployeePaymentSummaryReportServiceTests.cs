using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeePaymentSummaryReportServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/EmployeePaymentSummaryReport", new EmployeePaymentSummaryReportService(null, null).Route);
        }
    }
}
