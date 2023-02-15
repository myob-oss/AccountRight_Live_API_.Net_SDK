using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Report.JournalTransactionHistory
{
    /// <summary>
    /// Describes a Journal Transaction History  resource
    /// </summary>
    public class JournalTransactionHistory : BaseEntity
    {
        /// <summary>
        /// Journal transaction id.
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// The entry type
        /// </summary>
        public JournalType JournalType { get; set; }

        /// <summary>
        /// The transaction date
        /// </summary>
        public DateTime? DateOccurred { get; set; }

        /// <summary>
        /// Date transaction is entered into the system
        /// </summary>
        public DateTime? DatePosted { get; set; }

        /// <summary>
        /// Journal memo assigned to the transaction.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Journal line information
        /// </summary>
        public IEnumerable<JournalTransactionLine> Lines { get; set; }

        /// <summary>
        /// Source transaction information
        /// </summary>
        public SourceTransaction SourceTransaction { get; set; }

        /// <summary>
        /// Operation type
        /// </summary>
        public JournalTransactionOperationType OperationType { get; set; }

        /// <summary>
        /// UID of the first version of the transaction ( i.e. constant for subsequent operations)
        /// </summary>
        public Guid GroupUID { get; set; }
    }
}