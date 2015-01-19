using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes a Journal Transaction  resource
    /// </summary>
    public class JournalTransaction : BaseEntity
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
        /// Transaction date entry
        /// </summary>
        public DateTime? DateOccurred { get; set; }

        /// <summary>
        /// Date of the transaction 
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
    }
}