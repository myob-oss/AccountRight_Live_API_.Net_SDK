using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Descibes a Customer resource
    /// </summary>
    public class Customer : Contact
    {
        /// <summary>
        /// The selling details applied to the Customer
        /// </summary>
        public CustomerSellingDetails SellingDetails { get; set; }

        /// <summary>
        /// The paying details applied to the Customer
        /// </summary>
        public CustomerPaymentDetails PaymentDetails { get; set; }

        /// <summary>
        /// The Foreign Currency associated with the entity
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }
    }
}