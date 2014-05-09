using MYOB.AccountRight.SDK.Services.PayrollCategory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollCategoryWageServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/PayrollCategory/Wage", new PayrollCategoryWageService(null, null).Route);
        }
    }
}