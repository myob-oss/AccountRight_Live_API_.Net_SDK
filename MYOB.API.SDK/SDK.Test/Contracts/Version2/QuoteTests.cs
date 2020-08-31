using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class QuoteTests
    {
        [Test]
        public void QuoteIsCreatedWithDefaultValues()
        {
            var order = new Quote();

            Assert.IsTrue(order.IsTaxInclusive);
        }
    }
}