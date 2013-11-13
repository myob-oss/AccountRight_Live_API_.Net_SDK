namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the refund details for a supplier
    /// </summary>
    public class SupplierRefundDetails
    {
        /// <summary>
        /// Payment refund type.
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// The card number (Last 4 digits only.)
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Default name on card.
        /// </summary>
        public string NameOnCard { get; set; }

        /// <summary>
        /// Default refund payment notes.
        /// </summary>
        public string Notes { get; set; }
    }
}