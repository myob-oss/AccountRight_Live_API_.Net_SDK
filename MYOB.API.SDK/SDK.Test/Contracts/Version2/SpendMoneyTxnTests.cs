using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Banking;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class SpendMoneyTxnTests
    {
        [Test]
        public void Constructor_WhenNoParameters_DefaultsFields()
        {
            // Arrange, Act
            var sp = new SpendMoneyTxn();

            // Assert            
            Assert.AreEqual(PayFrom.Account, sp.PayFrom);
            Assert.AreNotEqual(DateTime.MinValue, sp.Date);
        }
    }
}