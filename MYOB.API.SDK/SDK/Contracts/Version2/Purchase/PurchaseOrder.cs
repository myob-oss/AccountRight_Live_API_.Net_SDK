using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/Order resource
    /// </summary>
    public class PurchaseOrder : SupportMulticurrencyEntity
    {
        /// <summary>
        /// Purchase order number
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// <remarks>{ 'Date': '2013-08-11 13:33:02' }</remarks>
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Invoice number
        /// </summary>
        public string SupplierInvoiceNumber { get; set; }

        /// <summary>
        /// The supplier
        /// </summary>
        public SupplierLink Supplier { get; set; }

        /// <summary>
        /// Shipto Address
        /// </summary>
        public string ShipToAddress { get; set; }

        /// <summary>
        /// Terms for the supplier
        /// </summary>
        public PurchaseTerms Terms { get; set; }

        /// <summary>
        /// True indicates the transaction is set to tax inclusive.
        /// False indicates the transaction is not tax inclusive.
        /// </summary>
        public bool IsTaxInclusive { get; set; }
        
        /// <summary>
        /// <para>True indicates the transaction is taxable.</para>
        /// <para>False indicates the transaction is not taxable.</para>
        /// </summary>
        public bool IsReportable { get; set; }
        
        // Order = 9 is for Lines in PurchaseOrderWithLines class
        
        /// <summary>
        /// Sum of all tax exclusive line amounts applicable to this purchase.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Tax freight amount applicable to the purchase order.
        /// </summary>
        /// <remarks>
        /// Only supported by Item or Service orders
        /// </remarks>
        public decimal? Freight { get; set; }

        /// <summary>
        /// The freight Tax code
        /// </summary>
        /// <remarks>
        /// Only supported by Item or Service orders
        /// </remarks>
        public TaxCodeLink FreightTaxCode { get; set; }

        /// <summary>
        /// Total of all tax amounts applicable to this purchase.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total amount of the purchase order.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The category associated with the purchase
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// Journal memo text describing the order.
        /// </summary>
        public string JournalMemo { get; set; }

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
        public PurchaseOrderStatus Status { get; set; }

        /// <summary>
        /// The date of the last payment made on the invoice
        /// </summary>
        public DateTime? LastPaymentDate { get; set; }

        /// <summary>
        /// The type of the order
        /// </summary>
        public OrderLayoutType OrderType { get; set; }
    }

    /// <summary>
    /// The status of an <see cref="PurchaseOrder" />
    /// </summary>
    public enum PurchaseOrderStatus
    {
        /// <summary>
        /// The order is still open
        /// </summary>
        Open,

        /// <summary>
        /// The order has since been converted to an bill
        /// </summary>
        ConvertedToBill
    }
}
