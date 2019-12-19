namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the SupplierPayment's Line
    /// </summary>
    public class SupplierPaymentLine
    {
        /// <summary>
        /// Sequence of the entry within the supplier payment set. 
        /// <para>ONLY required for updating an existing supplier payment line.</para>
        /// <para>NOT required when creating a new supplier payment.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// Is it an Bill or an Order 
        /// </summary>
        public SupplierPaymentLineType Type { get; set; }

        /// <summary>
        /// The Bill or Order Link (only need UID)
        /// </summary>
        public PurchaseLink Purchase { get; set; }

        /// <summary>
        /// Amount applied to the purchase.
        /// </summary>
        public decimal AmountApplied { get; set; }

        /// <summary>
        /// Foreign Amount applied to the purchase.
        /// </summary>
        public decimal? AmountAppliedForeign { get; set; }

        /// <summary>
        /// Any gain or loss made on this payment due to exchange rate differences.
        /// </summary>
        public decimal? GainOrLossAmount { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time. 
        /// <para>ONLY required for updating an existing supplier payment.</para>
        /// <para>NOT required when creating a new supplier payment.</para>
        /// </summary>
        public long RowVersion { get; set; }
    }
}