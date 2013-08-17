using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class MiscellaneousInvoiceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Invoice/Miscellaneous", new MiscellaneousInvoiceService(null, null).Route);
        }
    }
}