using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CreditRefundServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/CreditRefund", new CreditRefundService(null).Route);
        }
    }
}