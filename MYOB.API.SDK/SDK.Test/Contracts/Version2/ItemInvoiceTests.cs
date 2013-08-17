using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ItemInvoiceTests
    {
        [Test]
        public void InvoiceIsCreatedWithDefaultValues()
        {
            var invoice = new ItemInvoice();

            Assert.IsTrue(invoice.IsTaxInclusive);
            Assert.AreEqual(DocumentAction.Print, invoice.InvoiceDeliveryStatus);
        }
    }
}