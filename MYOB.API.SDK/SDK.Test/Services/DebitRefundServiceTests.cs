using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class DebitRefundServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/DebitRefund", new DebitRefundService(null).Route);
        }
    }
}