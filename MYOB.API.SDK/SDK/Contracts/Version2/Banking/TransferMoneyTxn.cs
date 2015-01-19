using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// A transfer money transaction entity
    /// </summary>
    public class TransferMoneyTxn : BaseEntity
    {
        /// <summary>
        /// The account to pay from
        /// </summary>
        public AccountLink FromAccount { get; set; }

        /// <summary>
        /// The account to pay to
        /// </summary>
        public AccountLink ToAccount { get; set; }

        /// <summary>
        /// The transfer number
        /// </summary>
        public string TransferNumber { get; set; }

        /// <summary>
        /// The date of the transfer
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The amount transferred
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// A custom memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// A category associated with the transfer
        /// </summary>
        public CategoryLink Category { get; set; }

    }
}