using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeePaymentDetailsServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/EmployeePaymentDetails", new EmployeePaymentDetailsService(null, null).Route);
        }
    }
}
