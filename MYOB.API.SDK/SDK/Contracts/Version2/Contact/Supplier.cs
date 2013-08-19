namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{

    public class Supplier : Contact
    {
        public SupplierBuyingDetails BuyingDetails { get; set; }
        public SupplierPaymentDetails PaymentDetails { get; set; }
    }
}