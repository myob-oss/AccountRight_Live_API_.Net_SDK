using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/Employee", new EmployeeService(null, null).Route);
        }
    }
}