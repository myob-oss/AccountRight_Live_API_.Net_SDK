namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// The Account Type
    /// </summary>
    /// <remarks>
    /// Is related to Classification
    /// </remarks>
    public enum AccountType
    {
        /// <summary>
        /// Has Asset classification
        /// </summary>
        Bank,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        AccountReceivable,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        OtherCurrentAsset,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        FixedAsset,

        /// <summary>
        /// Has Asset classification
        /// </summary>
        OtherAsset,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        CreditCard,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        AccountsPayable,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        OtherCurrentLiability,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        LongTermLiability,

        /// <summary>
        /// Has Liability classification
        /// </summary>
        OtherLiability,

        /// <summary>
        /// Has Equity classification
        /// </summary>
        Equity,

        /// <summary>
        /// Has Income classification
        /// </summary>
        Income,

        /// <summary>
        /// Has CostOfSales classification
        /// </summary>
        CostOfSales,

        /// <summary>
        /// Has Expense classification
        /// </summary>
        Expense,

        /// <summary>
        /// Has OtherIncome classification
        /// </summary>
        OtherIncome,

        /// <summary>
        /// Has OtherExpense classification
        /// </summary>
        OtherExpense,
    }
}