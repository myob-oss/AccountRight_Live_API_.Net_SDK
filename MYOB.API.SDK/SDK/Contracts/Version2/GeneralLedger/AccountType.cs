using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// The Account Type
    /// </summary>
    /// <remarks>
    /// Is related to Classification
    /// </remarks>
    [Flags]
    public enum AccountType
    {
        /// <summary>
        /// Has Asset classification
        /// </summary>
        Bank = 1,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        AccountReceivable = 2,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        OtherCurrentAsset = 4,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        FixedAsset = 8,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        OtherAsset = 16,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        CreditCard = 32,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        AccountsPayable = 64,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        OtherCurrentLiability = 128,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        LongTermLiability = 256,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        OtherLiability = 512,

        /// <summary>
        /// Has Equity classification
        /// </summary>
        Equity = 1024,

        /// <summary>
        /// Has Income classification
        /// </summary>
        Income = 2048,

        /// <summary>
        /// Has CostOfSales classification
        /// </summary>
        CostOfSales = 4096,

        /// <summary>
        /// Has Expense classification
        /// </summary>
        Expense = 8192,

        /// <summary>
        /// Has OtherIncome classification
        /// </summary>
        OtherIncome = 16384,

        /// <summary>
        /// Has OtherExpense classification
        /// </summary>
        OtherExpense = 32768,
    }
}