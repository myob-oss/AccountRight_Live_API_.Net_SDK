namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Link to the CustomerPayment resource
    /// </summary>
    public class CustomerPaymentLink : BaseLink
    {
        /// <summary>
        /// The receipt number of the payment
        /// </summary>
        public string ReceiptNumber { get; set; }
    }
}