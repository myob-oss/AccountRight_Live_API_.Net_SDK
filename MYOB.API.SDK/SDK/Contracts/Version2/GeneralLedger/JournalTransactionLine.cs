using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes an entry in the Journal transaction
    /// </summary>
    public class JournalTransactionLine
    {
        /// <summary>
        /// A link to the related <see cref="Account"/> resource
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The amount posted
        /// </summary>
        public Decimal Amount { get; set; }

        /// <summary>
        /// A link to the related <see cref="Job"/> resource
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// Indicates that the amount posted a credit to the Account object.
        /// </summary>
        public bool IsCredit { get; set; }

        /// <summary>
        /// Line description for each line of the transaction if one has been entered.
        /// </summary>
        public string LineDescription { get; set; }

        /// <summary>
        /// Date transaction has been reconciled
        /// </summary>
        public DateTime? ReconciledDate { get; set; }

        /// <summary>
        /// The quantity amount for this line
        /// </summary>
        public decimal? UnitCount { get; set; }
    }
}