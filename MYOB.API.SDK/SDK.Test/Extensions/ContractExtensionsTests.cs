using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Extensions;
using NUnit.Framework;

namespace SDK.Test.Extensions
{
    [TestFixture]
    public class ContractExtensionsTests
    {
        [Test]
        public void CorrectPrefixIsReturnedForClassification()
        {
            Assert.AreEqual(1, Classification.Asset.GetDisplayIdPrefix());
            Assert.AreEqual(2, Classification.Liability.GetDisplayIdPrefix());
            Assert.AreEqual(3, Classification.Equity.GetDisplayIdPrefix());
            Assert.AreEqual(4, Classification.Income.GetDisplayIdPrefix());
            Assert.AreEqual(5, Classification.CostOfSales.GetDisplayIdPrefix());
            Assert.AreEqual(6, Classification.Expense.GetDisplayIdPrefix());
            Assert.AreEqual(8, Classification.OtherIncome.GetDisplayIdPrefix());
            Assert.AreEqual(9, Classification.OtherExpense.GetDisplayIdPrefix());
        }
    }
}
