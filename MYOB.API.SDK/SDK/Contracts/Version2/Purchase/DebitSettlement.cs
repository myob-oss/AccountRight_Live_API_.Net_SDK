using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/DebitSettlement resource
    /// </summary>
    public class DebitSettlement : BaseEntity
    {
        /// <summary>
        /// A reference to the bill from where the debit note came from
        /// </summary>
        public BillLink DebitFromBill { get; set; }

        /// <summary>
        /// The supplier related to this debit note
        /// </summary>
        public SupplierLink Supplier { get; set; }

        /// <summary>
        /// The number of the debit note
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The date the debit note was applied
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The amount applied
        /// </summary>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// Extra details
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The bills and orders to which this settlement was applied
        /// </summary>
        public IEnumerable<DebitSettlementLine> Lines { get; set; }

        /// <summary>
        /// Foreign currency of the debit settlement
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }
    }
}