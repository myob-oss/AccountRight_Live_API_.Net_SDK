namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the CustomerPayment/RecordWithDiscountsAndFees' line
    /// </summary>
    public class CustomerPaymentRecordWithDiscountsAndFeesLine
    {
        /// <summary>
        /// The Invoice or Order Link (only need UID)
        /// </summary>
        public SaleLink Sale { get; set; }

        /// <summary>
        /// The amount of money applied
        /// </summary>
        public decimal AmountApplied { get; set; }

        /// <summary>
        /// The foreign amount of money applied
        /// </summary>
        public decimal AmountAppliedForeign { get; set; }

        /// <summary>
        /// The discount to be applied
        /// </summary>
        public decimal DiscountApplied { get; set; }

        /// <summary>
        /// The foreign discount to be applied
        /// </summary>
        public decimal DiscountAppliedForeign { get; set; }

        /// <summary>
        /// Is it an Invoice or an Order 
        /// </summary>
        public CustomerPaymentLineType Type { get; set; }
    }
}