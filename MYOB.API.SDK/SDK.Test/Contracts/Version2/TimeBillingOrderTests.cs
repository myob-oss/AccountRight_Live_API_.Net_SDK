using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class TimeBillingOrderTests
    {
        [Test]
        public void OrderIsCreatedWithDefaultValues()
        {
            var order = new TimeBillingOrder();

            Assert.AreEqual(DocumentAction.Print, order.DeliveryStatus);
        }
    }
}