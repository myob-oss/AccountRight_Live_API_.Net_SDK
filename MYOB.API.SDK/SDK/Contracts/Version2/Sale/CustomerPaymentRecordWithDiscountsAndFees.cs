using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the CustomerPayment/RecordWithDiscountsAndFees resource
    /// </summary>
    public class CustomerPaymentRecordWithDiscountsAndFees
    {
        /// <summary>
        /// The UID of the CustomerPayment (not yet supported)
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DepositTo DepositTo { get; set; }

        /// <summary>
        /// The account to pay to (only need UID)
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The customer making the payment
        /// </summary>
        public CustomerLink Customer { get; set; }

        /// <summary>
        /// The receipt number to assign
        /// </summary>
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// The date the transaction was made
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The finance charge to apply
        /// </summary>
        public decimal FinanceCharge { get; set; }

        /// <summary>
        /// The payment method
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Supplementary data
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The foreign currency related to this customerpayment
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// The exchange rate (to local) of ForeignCurrency related to this customerpayment
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }
        /// <summary>
        /// The Invoices or Orders being affected
        /// </summary>

        public IEnumerable<CustomerPaymentRecordWithDiscountsAndFeesLine> Lines { get; set; }
    }
}