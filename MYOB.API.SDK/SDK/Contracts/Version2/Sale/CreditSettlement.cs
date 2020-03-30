using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/CreditSettlement resource
    /// </summary>
    public class CreditSettlement : BaseEntity
    {
        /// <summary>
        /// A reference to the invoice from where the credit note came from
        /// </summary>
        public InvoiceLink CreditFromInvoice { get; set; }

        /// <summary>
        /// The customer related to this creditnote
        /// </summary>
        public CustomerLink Customer { get; set; }

        /// <summary>
        /// The foreign currency related to this creditsettlement
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// The number of the credit note
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The date the credit note was applied
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The amount applied
        /// </summary>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Extra details
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The invoices and orders to which this settlement was applied
        /// </summary>
        public IEnumerable<CreditSettlementLine> Lines { get; set; }
    }
}
