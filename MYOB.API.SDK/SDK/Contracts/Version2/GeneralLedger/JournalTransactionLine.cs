using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    public class JournalTransactionLine
    {
        public AccountLink Account { get; set; }

        public Decimal Amount { get; set; }

        public JobLink Job { get; set; }

        public bool IsCredit { get; set; }

        public string LineDescription { get; set; }

        public DateTime? ReconciledDate { get; set; }
    }
}