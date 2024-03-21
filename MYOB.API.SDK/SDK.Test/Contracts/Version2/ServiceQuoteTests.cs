﻿using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ServiceQuoteTests
    {
        [Test]
        public void QuoteIsCreatedWithDefaultValues()
        {
            var quote = new ServiceQuote();

            Assert.IsTrue(quote.IsTaxInclusive);
            Assert.AreEqual(DocumentAction.Print, quote.DeliveryStatus);
        }
    }
}