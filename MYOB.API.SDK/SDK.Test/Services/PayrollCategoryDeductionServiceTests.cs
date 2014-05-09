using MYOB.AccountRight.SDK.Services.PayrollCategory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollCategoryDeductionServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/PayrollCategory/Deduction", new PayrollCategoryDeductionService(null, null).Route);
        }
    }
}