using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Report.JournalTransactionHistory;
using NUnit.Framework;
using System;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class JournalTransactionHistoryTests
    {
        [Test]
        public void JournalTransactionHistoryIsCreatedWithDefaultValues()
        {
            var journalTransactionHistory = new JournalTransactionHistory();

            Assert.AreEqual(JournalTransactionOperationType.Added, journalTransactionHistory.OperationType);
            Assert.AreEqual(Guid.Empty, journalTransactionHistory.GroupUID);
        }
    }
}
