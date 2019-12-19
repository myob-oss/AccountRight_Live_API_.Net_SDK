using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the SupplierPayment/RecordWithDiscountsAndFees resource
    /// </summary>
    public class SupplierPaymentRecordWithDiscountsAndFees
    {
        /// <summary>
        /// The UID of the SupplierPayment (not yet supported)
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// If allocating a banking account for the payment specify Account. 
        /// If using electronic payments specify ElectronicPayments
        /// </summary>
        public PayFrom PayFrom { get; set; }

        /// <summary>
        /// The account to pay to (only need UID)
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Pay to supplier
        /// </summary>
        public SupplierLink Supplier { get; set; }

        /// <summary>
        /// Payee address of the purchase bill.
        /// </summary>
        public string PayeeAddress { get; set; }

        /// <summary>
        /// ONLY applicable for Electronic Payments.
        ///  Particulars attached to electronic payment.
        /// </summary>
        public string StatementParticulars { get; set; }

        /// <summary>
        /// ONLY APPLICABLE FOR NZ REGION.
        /// Code attached to electronic payment.
        /// </summary>
        public string StatementCode { get; set; }

        /// <summary>
        /// ONLY APPLICABLE FOR NZ REGION.
        /// Reference attached to electronic payment.
        /// </summary>
        public string StatementReference { get; set; }

        /// <summary>
        /// ID No of payment transaction
        /// </summary>
        public string PaymentNumber { get; set; }

        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// { 'Date': '2013-08-11 13:33:02' } 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Total of all amounts paid to the purchase bill/bills.
        /// </summary>
        public decimal FinanceCharge { get; set; }

        /// <summary>
        /// Memo text of the supplier payment entry.
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Payment to the purchases
        /// </summary>
        public IEnumerable<SupplierPaymentRecordWithDiscountsAndFeesLine> Lines { get; set; }

        /// <summary>
        /// Delivery status assigned to payment:
        /// <para>ToBePrinted</para>
        /// <para>ToBeEmailed</para>
        /// <para>ToBePrintedAndEmailed</para>
        /// <para>AlreadyPrintedOrSent</para>
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }

        /// <summary>
        /// Foreign currency of the payment.
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// Custom currency exchange rate.
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }

    }
}
