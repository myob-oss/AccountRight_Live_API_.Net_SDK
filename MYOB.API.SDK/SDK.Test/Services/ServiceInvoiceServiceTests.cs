using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ServiceInvoiceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Invoice/Service", new ServiceInvoiceService(null, null).Route);
        }
    }
}