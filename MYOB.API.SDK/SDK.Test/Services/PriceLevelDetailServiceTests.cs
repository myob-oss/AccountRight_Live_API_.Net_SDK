using System.Globalization;
using MYOB.AccountRight.SDK.Services.Inventory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PriceLevelDetailServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Inventory/PriceLevelDetail", new PriceLevelDetailService(null).Route);
        }
    } 
}