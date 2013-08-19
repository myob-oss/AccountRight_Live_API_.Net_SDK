using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    public class JournalTransaction : BaseEntity
    {
        public string DisplayID { get; set; }

        public JournalType JournalType { get; set; }

        public DateTime? DateOccurred { get; set; }

        public DateTime? DatePosted { get; set; }

        public string Description { get; set; }

        public IEnumerable<JournalTransactionLine> Lines { get; set; }

    }
}