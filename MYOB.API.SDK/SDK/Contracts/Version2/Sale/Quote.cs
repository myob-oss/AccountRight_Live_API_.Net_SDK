using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a basic sale quote
    /// </summary>
    public class Quote : BaseEntity
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public Quote()
        {
            IsTaxInclusive = true;
            Status = SaleQuoteStatus.Open;
        }

        /// <summary>
        /// The number
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Quote date entry
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
        public QuoteTerms Terms { get; set; }

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
        /// Tax freight amount applicable to the sale quote.
        /// </summary>
        /// <remarks>
        /// Only supported by Item or Service quotes
        /// </remarks>
        public decimal? Freight { get; set; }

        /// <summary>
        /// The freight Tax code
        /// </summary>
        /// <remarks>
        /// Only supported by Item or Service quotes
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
        /// The date of the last payment made on the quote?
        /// </summary>
        public DateTime? LastPaymentDate { get; set; }

        /// <summary>
        /// The type of quote
        /// </summary>
        public QuoteLayoutType QuoteType { get; set; }

        /// <summary>
        /// Foreign currency for multicurrency quotes.
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// Quote Status
        /// </summary>
        public SaleQuoteStatus Status { get; set; }
    }

    /// <summary>
    /// The terms of the <see cref="Quote" />
    /// </summary>
    public class QuoteTerms : Terms
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
        /// Date the invoice balance is due.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Finance Charge amount applicable to the invoice.
        /// </summary>
        public decimal? FinanceCharge { get; set; }
    }

}
