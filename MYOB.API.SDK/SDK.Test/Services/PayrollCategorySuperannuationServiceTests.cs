using MYOB.AccountRight.SDK.Services.PayrollCategory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollCategorySuperannuationServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/PayrollCategory/Superannuation", new PayrollCategorySuperannuationService(null, null).Route);
        }
    }
}