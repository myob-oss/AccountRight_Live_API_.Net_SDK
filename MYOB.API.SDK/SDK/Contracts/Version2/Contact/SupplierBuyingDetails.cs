using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the Supplier Buying Details
    /// </summary>
    public class SupplierBuyingDetails
    {
        /// <summary>
        /// The default purchase layout
        /// </summary>
        public PurchaseLayoutType PurchaseLayout { get; set; }

        /// <summary>
        /// Named form selected as default printed form.
        /// </summary>
        public string PrintedForm { get; set; }

        /// <summary>
        /// Default supplier delivery status.
        /// </summary>
        public DocumentAction? PurchaseOrderDelivery { get; set; }

        /// <summary>
        /// A link to the expense account resource
        /// </summary>
        public AccountLink ExpenseAccount { get; set; }

        /// <summary>
        /// Default payment memo.
        /// </summary>
        public string PaymentMemo { get; set; }

        /// <summary>
        /// Default selected purchase comment.
        /// </summary>
        public string PurchaseComment { get; set; }

        /// <summary>
        /// The suppliers hourly billing rate exclusive of tax.
        /// </summary>
        public decimal SupplierBillingRate { get; set; }

        /// <summary>
        /// Shipping method text.
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Indicates the supplier contact is setup for reportable taxable payments. (AU only)
        /// </summary>
        public bool IsReportable { get; set; }

        /// <summary>
        /// Cost per hour of providing the suppliers services when generating an activity slip.
        /// </summary>
        public decimal CostPerHour { get; set; }

        /// <summary>
        /// The supplier credit limit
        /// </summary>
        public SupplierCredit Credit { get; set; }

        /// <summary>
        /// ABN Number (Must be 11 digits and formatted as XX XXX XXX XXX).
        /// </summary>
        public string ABN { get; set; }

        /// <summary>
        /// ABN branch number.
        /// </summary>
        public string ABNBranch { get; set; }

        /// <summary>
        /// Tax id number.
        /// </summary>
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// A link to a tax code resource
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// A link to a Tax code resource for use with freight charges
        /// </summary>
        public TaxCodeLink FreightTaxCode { get; set; }

        /// <summary>
        /// Indicates to use the supplier tax code. 
        /// </summary>
        public bool UseSupplierTaxCode { get; set; }

        /// <summary>
        /// The supplier terms
        /// </summary>
        public SupplierTerms Terms { get; set; }
    }
}