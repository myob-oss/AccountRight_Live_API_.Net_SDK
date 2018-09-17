using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ItemQuoteTests
    {
        [Test]
        public void QuoteeIsCreatedWithDefaultValues()
        {
            var quote = new ItemQuote();

            Assert.IsTrue(quote.IsTaxInclusive);
            Assert.AreEqual(DocumentAction.Print, quote.DeliveryStatus);
        }
    }
}