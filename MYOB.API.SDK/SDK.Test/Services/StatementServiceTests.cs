using MYOB.AccountRight.SDK.Services.Banking;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class StatementServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Banking/Statement", new StatementService(null, null, null).Route);
        }
    }
}
