using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void OrderIsCreatedWithDefaultValues()
        {
            var order = new Order();

            Assert.IsTrue(order.IsTaxInclusive);
        }
    }
}