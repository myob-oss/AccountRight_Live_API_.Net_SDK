using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// A spend money transaction entity
    /// </summary>
    public class SpendMoneyTxn : SupportMulticurrencyEntity
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public SpendMoneyTxn()
        {
            PayFrom = PayFrom.Account;
            Date = DateTime.Now;
        }

        /// <summary>
        /// If allocating a banking account for the payment specify Account. 
        /// If using electronic payments specify ElectronicPayments
        /// </summary>
        public PayFrom PayFrom { get; set; }

        /// <summary>
        /// The account to pay to
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The Contact (Card) associated with the transaction
        /// </summary>
        public CardLink Contact { get; set; }

        /// <summary>
        /// Payee address of the Contact.
        /// </summary>
        public string PayeeAddress { get; set; }

        /// <summary>
        /// ONLY applicable for Electronic Payments.
        ///  Particulars attached to electronic payment.
        /// </summary>
        public string StatementParticulars { get; set; }

        /// <summary>
        /// Statement Code (New Zealand only)
        /// </summary>
        public string StatementCode { get; set; }

        /// <summary>
        /// Statement Reference (New Zealand only)
        /// </summary>
        public string StatementReference { get; set; }

        /// <summary>
        /// Transaction Payment Number
        /// </summary>
        public string PaymentNumber { get; set; }

        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// { 'Date': '2013-08-11 13:33:02' } 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Total Amount Paid
        /// <remarks>Read-only</remarks>
        /// </summary>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// <para>True indicates the transaction is set to tax inclusive.</para>
        /// <para>False indicates the transaction is not tax inclusive.</para>
        /// </summary>
        public bool IsTaxInclusive { get; set; }

        /// <summary>
        /// Total of all tax amounts applicable to the transaction.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Memo text describing the transaction.
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Transaction Lines
        /// </summary>
        public IEnumerable<SpendMoneyTxnLine> Lines { get; set; }

        /// <summary>
        /// Was a cheque printed
        /// </summary>
        public bool ChequePrinted { get; set; }

        /// <summary>
        /// Delivery status assigned to payment:
        /// <para>ToBePrinted</para>
        /// <para>ToBeEmailed</para>
        /// <para>ToBePrintedAndEmailed</para>
        /// <para>AlreadyPrintedOrSent</para>
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }

        /// <summary>
        /// The Category associated with the transaction
        /// </summary>
        public CategoryLink Category { get; set; }
    }
}