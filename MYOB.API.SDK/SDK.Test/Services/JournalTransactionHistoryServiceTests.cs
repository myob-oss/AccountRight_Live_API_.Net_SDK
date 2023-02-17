using MYOB.AccountRight.SDK.Services.Report.JournalTransactionHistory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class JournalTransactionHistoryServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Report/JournalTransactionHistory", new JournalTransactionHistoryService(null).Route);
        }
    }
}