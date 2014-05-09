using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/Bill resource
    /// </summary>
    public class Bill : BaseEntity
    {
        /// <summary>
        /// Purchase bill number
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// <remarks>{ 'Date': '2013-08-11 13:33:02' }</remarks>
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Supplier invoice number.
        /// </summary>
        public string SupplierInvoiceNumber { get; set; }
        
        /// <summary>
        /// Supplier of the purchase bill.
        /// </summary>
        public SupplierLink Supplier { get; set; }
        
        /// <summary>
        /// ShipTo address of the purchase bill.
        /// </summary>
        public string ShipToAddress { get; set; }

        /// <summary>
        /// The payment terms
        /// </summary>
        public Terms Terms { get; set; }

        /// <summary>
        /// <para>True indicates the transaction is set to tax inclusive.</para>
        /// <para>False indicates the transaction is not tax inclusive.</para>
        /// </summary>
        public bool IsTaxInclusive { get; set; }

        /// <summary>
        /// <para>True indicates the transaction is taxable.</para>
        /// <para>False indicates the transaction is not taxable.</para>
        /// </summary>
        public bool? IsReportable { get; set; }

        /// <summary>
        /// Sum of all tax exclusive line amounts.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Total of all tax amounts applicable.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// The total amount
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// A general comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// What is the shipping method
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// When is the payment promised
        /// </summary>
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Journal memo text describing the bill.
        /// </summary>
        public string JournalMemo { get; set; }
        
        /// <summary>
        /// Bill delivery status assigned.
        /// </summary>
        public DocumentAction BillDeliveryStatus { get; set; }

        /// <summary>
        /// How much has been paid to date
        /// </summary>
        public decimal AppliedToDate { get; set; }

        /// <summary>
        /// The outstanding balance
        /// </summary>
        public decimal BalanceDueAmount { get; set; }

        /// <summary>
        /// The current status of the purchase
        /// </summary>
        public PurchaseStatus Status { get; set; }

        /// <summary>
        /// The date of the last payment made on the invoice
        /// </summary>
        /// <remarks>
        /// Availability: 2013.5 (Cloud), 2014.1 (Desktop)
        /// </remarks>
        public DateTime? LastPaymentDate { get; set; }

        /// <summary>
        /// The type of Bill - this is only populated when querying the "/Purchase/Bill" endpoint
        /// </summary>
        public BillType BillType { get; set; }

        /// <summary>
        /// The Bill Category
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// Tax freight amount applicable to the purchase bill.
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous bills
        /// </remarks>
        public decimal? Freight { get; set; }

        /// <summary>
        /// The freight Tax code
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous bills
        /// </remarks>
        public TaxCodeLink FreightTaxCode { get; set; }

    }
}
