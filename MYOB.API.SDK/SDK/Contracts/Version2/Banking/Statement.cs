using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// Bank Statement
    /// </summary>
    public class Statement : BaseEntity
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateTime StatementDate { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Is the transaction a Credit or a Debit
        /// </summary>
        public bool IsCredit { get; set; }

        /// <summary>
        /// Source transactions
        /// </summary>
        public IEnumerable<SourceTransaction> SourceTransactions { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatementStatus Status { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        public string Reference { get; set; }
    }

    /// <summary>
    /// Statement status
    /// </summary>
    public enum StatementStatus
    {
        /// <summary>
        /// Uncoded (corresponds to Unmatached)
        /// </summary>
        Uncoded,

        /// <summary>
        /// Coded (corresponds to Approved)
        /// </summary>
        Coded,

        /// <summary>
        /// Hidden
        /// </summary>
        Hidden
    }
}
