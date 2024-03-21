using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class SupplierServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/Supplier", new SupplierService(null, null).Route);
        }
    }
}