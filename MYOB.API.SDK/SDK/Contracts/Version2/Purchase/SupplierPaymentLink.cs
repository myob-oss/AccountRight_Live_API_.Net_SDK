namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Link to the SupplierPayment resource
    /// </summary>
    public class SupplierPaymentLink : BaseLink
    {
        /// <summary>
        /// Payment number of supplier payment
        /// </summary>
        public string PaymentNumber { get; set; }
    }
}
