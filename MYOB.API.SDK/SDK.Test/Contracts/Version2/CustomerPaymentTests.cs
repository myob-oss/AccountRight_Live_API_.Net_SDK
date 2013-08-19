using System;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class CustomerPaymentTests
    {
        [Test]
        public void AccountIsCreatedWithDefaultValues()
        {
            var cp = new CustomerPayment();

            Assert.AreEqual(DepositTo.Account, cp.DepositTo);
            Assert.AreNotEqual(DateTime.MinValue, cp.Date);
        }
    }
}