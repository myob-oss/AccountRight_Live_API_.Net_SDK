using MYOB.AccountRight.SDK.Services.PayrollCategory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollEmploymentClassificationTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/EmploymentClassification", new PayrollEmploymentClassificationService(null, null).Route);
        }
    }
}