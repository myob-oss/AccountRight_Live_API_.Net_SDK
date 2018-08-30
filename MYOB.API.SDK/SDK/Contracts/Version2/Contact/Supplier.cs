using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the Supplier resource
    /// </summary>
    public class Supplier : Contact
    {
        /// <summary>
        /// The default buying details
        /// </summary>
        public SupplierBuyingDetails BuyingDetails { get; set; }

        /// <summary>
        /// The default payment details
        /// </summary>
        public SupplierPaymentDetails PaymentDetails { get; set; }

        /// <summary>
        /// The Foreign Currency associated with the entity
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }
    }
}