namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    ///   GeneralJournalLine schema
    /// </summary>
    public class GeneralJournalLine
    {
        /// <summary>
        /// Row's Id (Read Only)
        /// </summary>
        public int RowId { get; set; }

        /// <summary>
        /// Row's timestamp (Read Only)
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        ///   Account Number
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        ///   Job Id
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        ///   Memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        ///  Tax Code
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Represents a Credit Amount if <see cref="IsCredit"/> equals True
        /// Represents a Debit Amount if <see cref="IsCredit"/> equals False
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Represents a foreign Credit Amount if <see cref="IsCredit"/> equals True
        /// Represents a foreign Debit Amount if <see cref="IsCredit"/> equals False
        /// </summary>
        public decimal? AmountForeign { get; set; }

        /// <summary>
        /// <see cref="Amount"/> Is Credit
        /// </summary>
        public bool IsCredit { get; set; }

        /// <summary>
        ///  Tax Amount
        ///  The value written in Tax Amount is only taken into account if <see cref="IsOverriddenTaxAmount"/> equals True
        /// </summary>
        public decimal TaxAmount { get; set; }
        
        /// <summary>
        /// Tax Foreign Amount
        /// </summary>
        public decimal? TaxAmountForeign { get; set; }

        /// <summary>
        /// By setting this flag to True, the Tax will be set to the value of TaxAmount. 
        /// </summary>
        public bool IsOverriddenTaxAmount { get; set; }

        /// <summary>
        /// The quantity amount for this line
        /// </summary>
        public decimal? UnitCount { get; set; }
    }
}