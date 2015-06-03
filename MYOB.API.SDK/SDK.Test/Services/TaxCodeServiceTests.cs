using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class TaxCodeServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/TaxCode", new TaxCodeService(null, null).Route);
        }
    }
}