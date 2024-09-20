using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class PriceLevelDetailTests
    {
        [Test]
        public void PriceLevelDetailIsCreatedWithDefaultValues()
        {
            var priceLevelDetail = new PriceLevelDetail();

            Assert.AreEqual(null, priceLevelDetail.Name);
            Assert.AreEqual(null, priceLevelDetail.Value);
        }
    }
}