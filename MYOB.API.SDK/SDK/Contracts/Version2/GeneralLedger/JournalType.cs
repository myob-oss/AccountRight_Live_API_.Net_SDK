namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// The type of journal entry
    /// </summary>
    public enum JournalType
    {
        /// <summary>
        /// General
        /// </summary>
        General,

        /// <summary>
        /// Sales 
        /// </summary>
        Sale,

        /// <summary>
        /// Purchases 
        /// </summary>
        Purchase,

        /// <summary>
        /// Cash payments
        /// </summary>
        CashPayment,

        /// <summary>
        /// Cash receipts
        /// </summary>
        CashReceipt,

        /// <summary>
        /// Inventory
        /// </summary>
        Inventory,
    }
}