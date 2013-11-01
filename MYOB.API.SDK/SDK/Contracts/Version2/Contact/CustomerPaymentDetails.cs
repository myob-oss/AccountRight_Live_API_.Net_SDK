namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the customer payment details
    /// </summary>
    public class CustomerPaymentDetails
    {
        /// <summary>
        /// Default payment method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The card number (last 4 digits only)
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Default name on the card
        /// </summary>
        public string NameOnCard { get; set; }

        /// <summary>
        /// The bank account BSB number
        /// </summary>
        public string BSBNumber { get; set; }

        /// <summary>
        /// The bank account number
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The bank account name
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// Additional notes
        /// </summary>
        public string Notes { get; set; }
    }
}