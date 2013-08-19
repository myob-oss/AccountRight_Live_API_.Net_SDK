using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/Customer", new CustomerService(null, null).Route);
        }
    }
}