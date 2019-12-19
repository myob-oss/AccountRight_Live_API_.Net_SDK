using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class GeneralJournalLineTests
    {
        [Test]
        public void Constructor_WhenNoParameters_UnitCountDefaultNull()
        {
            // Arrange, Act
            var generalJournalLine = new GeneralJournalLine();

            // Assert            
            Assert.AreEqual(null, generalJournalLine.UnitCount);
        }
    }
}
