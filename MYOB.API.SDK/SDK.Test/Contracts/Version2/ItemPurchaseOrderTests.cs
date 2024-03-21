using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ItemPurchaseOrderTests
    {
        [Test]
        public void OrderIsCreatedWithDefaultValues()
        {
            var order = new ItemPurchaseOrder();

            Assert.AreEqual(DocumentAction.Print, order.OrderDeliveryStatus);
        }
    }
}