namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{

    /// <summary>
    /// Account classification
    /// </summary>
    public enum Classification
    {
        /// <summary>
        /// Accounts that have a DisplayID of 1-...
        /// </summary>
        Asset,

        /// <summary>
        /// Accounts that have a DisplayID of 2-...
        /// </summary>
        Liability,

        /// <summary>
        /// Accounts that have a DisplayID of 3-...
        /// </summary>
        Equity,

        /// <summary>
        /// Accounts that have a DisplayID of 4-...
        /// </summary>
        Income,

        /// <summary>
        /// Accounts that have a DisplayID of 5-...
        /// </summary>
        CostOfSales,

        /// <summary>
        /// Accounts that have a DisplayID of 6-...
        /// </summary>
        Expense,

        /// <summary>
        /// Accounts that have a DisplayID of 8-...
        /// </summary>
        OtherIncome,

        /// <summary>
        /// Accounts that have a DisplayID of 9-...
        /// </summary>
        OtherExpense,
    }
}