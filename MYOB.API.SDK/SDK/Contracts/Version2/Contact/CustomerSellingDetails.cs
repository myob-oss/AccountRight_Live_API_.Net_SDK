using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the customer selling details
    /// </summary>
    public class CustomerSellingDetails
    {
        /// <summary>
        /// The default invoice type for this customer
        /// </summary>
        public InvoiceLayoutType SaleLayout { get; set; }

        /// <summary>
        /// The default invoice delivery 
        /// </summary>
        public DocumentAction? InvoiceDelivery { get; set; }

        /// <summary>
        /// The name selected as the default printed form
        /// </summary>
        public string PrintedForm { get; set; }

        /// <summary>
        /// The Item price level (read-only)
        /// </summary>
        public string ItemPriceLevel { get; set; }

        /// <summary>
        /// A link to the income account
        /// </summary>
        public AccountLink IncomeAccount { get; set; }

        /// <summary>
        /// Default receipt memo
        /// </summary>
        public string ReceiptMemo { get; set; }

        /// <summary>
        /// A link to the salesperson resource
        /// </summary>
        public EmployeeLink SalesPerson { get; set; }

        /// <summary>
        /// The default sale comment
        /// </summary>
        public string SaleComment { get; set; }

        /// <summary>
        /// Shipping method text
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// The customers houly billing rate
        /// </summary>
        public decimal HourlyBillingRate { get; set; }

        /// <summary>
        /// ABN Number (Must be 11 digits and formatted as XX XXX XXX XXX)
        /// </summary>
        public string ABN { get; set; }

        /// <summary>
        /// The ABN Branch number
        /// </summary>
        public string ABNBranch { get; set; }

        /// <summary>
        /// A link to a tax code resource
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// A link to the tax code resource to apply to freight
        /// </summary>
        public TaxCodeLink FreightTaxCode { get; set; }

        /// <summary>
        /// Indicates whether to use the customer tax code
        /// </summary>
        public bool UseCustomerTaxCode { get; set; }

        /// <summary>
        /// The customer terms
        /// </summary>
        public CustomerTerms Terms { get; set; }

        /// <summary>
        /// The customer credit situation
        /// </summary>
        public CustomerCredit Credit { get; set; }

        /// <summary>
        /// Tax id number.
        /// </summary>
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// Default memo text
        /// </summary>
        public string Memo { get; set; }
    }
}