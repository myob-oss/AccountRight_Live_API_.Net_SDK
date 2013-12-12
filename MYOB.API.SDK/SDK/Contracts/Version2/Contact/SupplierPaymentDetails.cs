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
        /// Default statement text. (NZ this is known as statement particulars)
        /// </summary>
        public string StatementText { get; set; }

        /// <summary>
        /// Default statement code. (NZ only)
        /// </summary>
        public string StatementCode { get; set; }

        /// <summary>
        /// Default statement text. (NZ only)
        /// </summary>
        public string StatementReference { get; set; }

        /// <summary>
        /// The refund details
        /// </summary>
        public SupplierRefundDetails Refund { get; set; }
    }
}