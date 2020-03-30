using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a basic sale order
    /// </summary>
    public class Order : SupportMulticurrencyEntity
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public Order()
        {
            IsTaxInclusive = true;
        }

        /// <summary>
        /// The number
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Order date entry
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Customer PO number
        /// </summary>
        public string CustomerPurchaseOrderNumber { get; set; }

        /// <summary>
        /// The customer
        /// </summary>
        public CustomerLink Customer { get; set; }

        /// <summary>
        /// Customer payment terms
        /// </summary>
        public OrderTerms Terms { get; set; }

        /// <summary>
        /// True indicates the transaction is set to tax inclusive.
        /// False indicates the transaction is not tax inclusive.
        /// </summary>
        public bool IsTaxInclusive { get; set; }

        /// <summary>
        /// Sum of all tax exclusive line amounts applicable to the sale invoice.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Tax freight amount applicable to the sale order.
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
        /// Total of all tax amounts applicable to the sale invoice.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total amount of the sale invoice.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The category assocated with the Invoice
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// The employee contact
        /// </summary>
        public EmployeeLink Salesperson { get; set; }

        /// <summary>
        /// Journal memo text describing the sale.
        /// </summary>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Referral Source selected on the sale invoice.
        /// </summary>
        public string ReferralSource { get; set; }

        /// <summary>
        /// The amount paid to date
        /// </summary>
        public decimal AppliedToDate { get; set; }

        /// <summary>
        /// The balance due
        /// </summary>
        public decimal BalanceDueAmount { get; set; }

        /// <summary>
        /// The current status of the order
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// The date of the last payment made on the order
        /// </summary>
        public DateTime? LastPaymentDate { get; set; }

        /// <summary>
        /// The type of order
        /// </summary>
        public OrderLayoutType OrderType { get; set; }
    }

    /// <summary>
    /// The status of an <see cref="Order" />
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// The order is still open
        /// </summary>
        Open,

        /// <summary>
        /// The order has since been converted to an invoice
        /// </summary>
        ConvertedToInvoice
    }

    /// <summary>
    /// Describe the Sale Order's terms
    /// </summary>
    public class OrderTerms : Terms
    {
        /// <summary>
        /// % monthly charge for late payment.
        /// </summary>
        public double MonthlyChargeForLatePayment { get; set; }

        /// <summary>
        /// The date the discount (if exists) will expire.
        /// </summary>
        public DateTime? DiscountExpiryDate { get; set; }

        /// <summary>
        /// The discount applicable if the amount if paid before the discount expiry date
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// The foreign currency discount applicable if the amount if paid before the discount expiry date
        /// </summary>
        public decimal? DiscountForeign { get; set; }

        /// <summary>
        /// Date the invoice balance is due.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Finance Charge amount applicable to the invoice.
        /// </summary>
        public decimal? FinanceCharge { get; set; }

        /// <summary>
        /// Finance Charge foreign currency amount applicable to the invoice.
        /// </summary>
        public decimal? FinanceChargeForeign { get; set; }
    }
}