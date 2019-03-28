using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/DebitRefund resource
    /// </summary>
    public class DebitRefund : BaseEntity
    {
        /// <summary>
        /// Use the supplied account or use the undeposited funds account
        /// </summary>
        public DepositTo DepositTo { get; set; }

        /// <summary>
        /// The account to use
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The bill associated with the refund
        /// </summary>
        public BillLink Bill { get; set; }

        /// <summary>
        /// The supplier
        /// </summary>
        public SupplierLink Supplier { get; set; }

        /// <summary>
        /// The refund number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The date of the refund
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The amount of the refund
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The foreign currency related to this debitrefund
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// Additional information
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The payment method
        /// </summary>
        public string PaymentMethod { get; set; }
    }
}