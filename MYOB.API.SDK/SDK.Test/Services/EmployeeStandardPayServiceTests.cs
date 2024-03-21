using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeeStandardPayServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/EmployeeStandardPay", new EmployeeStandardPayService(null, null).Route);
        }
    }
}
