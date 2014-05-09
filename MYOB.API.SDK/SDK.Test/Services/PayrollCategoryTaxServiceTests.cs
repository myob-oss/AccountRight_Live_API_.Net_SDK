using MYOB.AccountRight.SDK.Services.PayrollCategory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollCategoryTaxServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/PayrollCategory/Tax", new PayrollCategoryTaxService(null, null).Route);
        }
    }
}