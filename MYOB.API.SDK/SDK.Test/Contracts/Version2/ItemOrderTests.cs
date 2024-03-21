using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ItemOrderTests
    {
        [Test]
        public void OrdereIsCreatedWithDefaultValues()
        {
            var order = new ItemOrder();

            Assert.IsTrue(order.IsTaxInclusive);
            Assert.AreEqual(DocumentAction.Print, order.DeliveryStatus);
        }
    }
}