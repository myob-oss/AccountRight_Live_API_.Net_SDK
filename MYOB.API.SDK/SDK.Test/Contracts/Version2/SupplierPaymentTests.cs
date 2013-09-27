using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class SupplierPaymentTests
    {
        [Test]
        public void Constructor_WhenNoParameters_DefaultsFields()
        {
            // Arrange, Act
            var sp = new SupplierPayment();

            // Assert            
            Assert.AreEqual(PayFrom.Account, sp.PayFrom);
            Assert.AreNotEqual(DateTime.MinValue, sp.Date);
        }
    }
}