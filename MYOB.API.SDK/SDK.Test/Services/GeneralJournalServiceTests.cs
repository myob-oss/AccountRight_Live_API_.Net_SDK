using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class GeneralJournalServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/GeneralJournal", new GeneralJournalService(null, null).Route);
        }
    }
}