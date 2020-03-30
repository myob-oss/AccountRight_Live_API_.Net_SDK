using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Common class for sale Professional, Miscelleneous, Service and Item invoice resource
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Sales invoice number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Transaction date entry
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Customer PO number
        /// </summary>
        public string CustomerPurchaseOrderNumber { get; set; }

        /// <summary>
        /// The customer
        /// </summary>
        public CardLink Customer { get; set; }

        /// <summary>
        /// Transaction promised date
        /// </summary>
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Amount still payable on the sales invoice
        /// </summary>
        public decimal BalanceDueAmount { get; set; }

        /// <summary>
        /// Amount still payable on the sales invoice in foreign currency
        /// </summary>
        public decimal? BalanceDueAmountForeign { get; set; }

        /// <summary>
        /// Invoice status
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}