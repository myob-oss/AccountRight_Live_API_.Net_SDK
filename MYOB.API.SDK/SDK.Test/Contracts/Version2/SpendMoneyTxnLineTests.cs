using MYOB.AccountRight.SDK.Contracts.Version2.Banking;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class SpendMoneyTxnLineTests
    {
        [Test]
        public void Constructor_WhenNoParameters_UnitCountDefaultNull()
        {
            // Arrange, Act
            var spendMoneyTxnLine = new SpendMoneyTxnLine();

            // Assert            
            Assert.AreEqual(null, spendMoneyTxnLine.UnitCount);
        }
    }
}