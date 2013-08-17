using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ProfessionalInvoiceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Invoice/Professional", new ProfessionalInvoiceService(null, null).Route);
        }
    }
}