using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class MiscellaneousInvoiceTests
    {
        [Test]
        public void InvoiceIsCreatedWithDefaultValues()
        {
            var invoice = new MiscellaneousInvoice();

            Assert.IsTrue(invoice.IsTaxInclusive);
        }
    }
}