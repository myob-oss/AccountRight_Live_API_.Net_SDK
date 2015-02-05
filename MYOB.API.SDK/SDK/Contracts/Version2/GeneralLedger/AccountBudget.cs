using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// The Account Budgets for a financial year
    /// </summary>
    public class AccountBudget 
    {
        /// <summary>
        /// The financial year of the budget
        /// </summary>
        public int FinancialYear { get; set; }

        /// <summary>
        /// The last month of the financial year
        /// </summary>
        public int LastMonthInFinancialYear { get; set; }

        /// <summary>
        /// The monthly account budgets
        /// </summary>
        public AccountMonthlyBudget[] Budgets { get; set; }

        /// <summary>
        /// AccountBudget Uri
        /// </summary>
        public Uri URI { get; set; }
    }

    /// <summary>
    /// The <see cref="MonthlyBudget"/>s for an <see cref="Account"/>
    /// </summary>
    public class AccountMonthlyBudget
    {
        /// <summary>
        /// The Account
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The monthly budgets for the related account
        /// </summary>
        public MonthlyBudget[] MonthlyBudgets { get; set; }
    }

    /// <summary>
    /// A monthly budget
    /// </summary>
    public class MonthlyBudget
    {
        /// <summary>
        /// The applicable year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The applicable month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// The allocated budget
        /// </summary>
        public decimal Amount { get; set; }
    }
}
