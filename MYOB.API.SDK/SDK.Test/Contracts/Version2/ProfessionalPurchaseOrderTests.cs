using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ProfessionalPurchaseOrderTests
    {
        [Test]
        public void OrderIsCreatedWithDefaultValues()
        {
            var order = new ProfessionalPurchaseOrder();

            Assert.AreEqual(DocumentAction.Print, order.OrderDeliveryStatus);
        }
    }
}