using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/CreditRefund resource
    /// </summary>
    public class CreditRefund : SupportMulticurrencyEntity
    {
        /// <summary>
        /// The account
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The invoice to which the refund originated
        /// </summary>
        public InvoiceLink Invoice { get; set; }

        /// <summary>
        /// The customer to whom the refund was made
        /// </summary>
        public CustomerLink Customer { get; set; }

        /// <summary>
        /// The address of the Payee
        /// </summary>
        public string Payee { get; set; }

        /// <summary>
        /// The cheue number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The data the refund was made
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The amount of the refund
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// additional information
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Was a cheque printed
        /// </summary>
        public bool ChequePrinted { get; set; }

        /// <summary>
        /// The current delivery status of the refund
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }



    }
}