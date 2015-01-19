using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class MiscellaneousOrderTests
    {
        [Test]
        public void OrderIsCreatedWithDefaultValues()
        {
            var order = new MiscellaneousOrder();

            Assert.IsTrue(order.IsTaxInclusive);
            Assert.AreEqual(DocumentAction.Print, order.DeliveryStatus);
        }
    }
}