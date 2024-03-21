using System.Collections.Generic;
using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ItemInvoiceServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Invoice/Item", new ItemInvoiceService(null, null).Route);
        }
    }
}