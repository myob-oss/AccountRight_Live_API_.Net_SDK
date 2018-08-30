using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class TimeBillingQuoteTests
    {
        [Test]
        public void QuoteIsCreatedWithDefaultValues()
        {
            var quote = new TimeBillingQuote();

            Assert.AreEqual(DocumentAction.Print, quote.DeliveryStatus);
        }
    }
}