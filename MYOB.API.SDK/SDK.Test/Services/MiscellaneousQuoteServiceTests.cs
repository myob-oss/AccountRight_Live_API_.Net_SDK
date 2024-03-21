using MYOB.AccountRight.SDK.Services.Sale;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class MiscellaneousQuoteServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Sale/Quote/Miscellaneous", new MiscellaneousQuoteService(null, null).Route);
        }
    }
}