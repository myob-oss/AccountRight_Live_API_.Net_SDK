using MYOB.AccountRight.SDK.Services.Report.Payroll;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeePayrollAdviceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/Payroll/EmployeePayrollAdvice", new EmployeePayrollAdviceService(null, null).Route);
        }
    }
}