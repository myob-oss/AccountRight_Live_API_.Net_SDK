using MYOB.AccountRight.SDK.Services.Version2.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeePayrollDetailsServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/EmployeePayrollDetails", new EmployeePayrollDetailsService(null, null).Route);
        }
    }
}
