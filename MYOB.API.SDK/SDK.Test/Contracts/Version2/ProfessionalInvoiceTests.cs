using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ProfessionalInvoiceTests
    {
        [Test]
        public void InvoiceIsCreatedWithDefaultValues()
        {
            var invoice = new ProfessionalInvoice();

            Assert.IsTrue(invoice.IsTaxInclusive);
            Assert.AreEqual(DocumentAction.Print, invoice.InvoiceDeliveryStatus);
        }
    }
}