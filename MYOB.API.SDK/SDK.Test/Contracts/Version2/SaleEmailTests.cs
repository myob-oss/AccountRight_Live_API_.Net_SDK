using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class SaleEmailTests
    {
        [Test]
        public void SaleEmailSIsCreatedWithDefaultValues()
        {
            var saleEmail = new SaleEmail();

            Assert.AreEqual(saleEmail.Message, null);
        }
    }
}