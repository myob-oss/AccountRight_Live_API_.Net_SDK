namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the supplier payment details
    /// </summary>
    public class SupplierPaymentDetails
    {
        /// <summary>
        /// Default bank account bsb number.
        /// </summary>
        public string BSBNumber { get; set; }

        /// <summary>
        /// Default bank account number.
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Default bank account name.
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// Default statement text.
        /// </summary>
        public string StatementText { get; set; }

        /// <summary>
        /// The refund details
        /// </summary>
        public SupplierRefundDetails Refund { get; set; }
    }
}