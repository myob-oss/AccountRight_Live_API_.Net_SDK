namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the SupplierPayment/RecordWithDiscountsAndFees' line
    /// </summary>
    public class SupplierPaymentRecordWithDiscountsAndFeesLine
    {
        /// <summary>
        /// The Bill or Order Link (only need UID)
        /// </summary>
        public PurchaseLink Purchase { get; set; }

        /// <summary>
        /// Amount applied to the purchase.
        /// </summary>
        public decimal AmountApplied { get; set; }

        /// <summary>
        /// Discount applied to the purchase.
        /// </summary>
        public decimal DiscountApplied { get; set; }

        /// <summary>
        /// Foreign Amount applied to the purchase.
        /// </summary>
        public decimal AmountAppliedForeign { get; set; }

        /// <summary>
        /// Foreign Discount applied to the purchase.
        /// </summary>
        public decimal DiscountAppliedForeign { get; set; }

        /// <summary>
        /// Is it an Bill or an Order 
        /// </summary>
        public SupplierPaymentLineType Type { get; set; }
    }
}
