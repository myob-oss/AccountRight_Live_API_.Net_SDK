namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    ///   Customer
    /// </summary>
    public class Customer : Contact
    {
        public CustomerSellingDetails SellingDetails { get; set; }
        public CustomerPaymentDetails PaymentDetails { get; set; }
    }
}