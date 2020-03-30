using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the CustomerPayment resource
    /// </summary>
    public class CustomerPayment : BaseEntity
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public CustomerPayment()
        {
            DepositTo = DepositTo.Account;
            Date = DateTime.Now;
        }

        /// <summary>
        /// <para>If allocating a banking account for the payment specify Account</para>
        /// <para>If using undeposited funds specify UndepositedFunds</para>
        /// </summary>
        public DepositTo DepositTo { get; set; }
        
        /// <summary>
        /// The account to deposit to (only need UID)
        /// </summary>
        public AccountLink Account { get; set; }
        
        /// <summary>
        /// Pay to customer
        /// </summary>
        public CardLink Customer { get; set; }

        /// <summary>
        /// ID No of payment transaction
        /// </summary>
        public Guid? TransactionUID { get; set; }

        /// <summary>
        /// Receipt No of payment transaction
        /// </summary>
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// <para><example>{ 'Date': '2013-08-11 13:33:02' }</example></para>
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Total of all amounts applicable to the sale invoice.
        /// </summary>
        public decimal AmountReceived { get; set; }

        /// <summary>
        /// Total of all Foreign amounts applicable to the sale invoice.
        /// </summary>
        public decimal? AmountReceivedForeign { get; set; }

        /// <summary>
        /// The foreign currency related to this customerpayment
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// The exchange rate (to local) of ForeignCurrency related to this customerpayment
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }

        /// <summary>
        /// Payment method text.
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Memo text of the customer payment entry.
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Collection of invoice to pay
        /// </summary>
        public IEnumerable<CustomerPaymentLine> Invoices { get; set; }
    }
}