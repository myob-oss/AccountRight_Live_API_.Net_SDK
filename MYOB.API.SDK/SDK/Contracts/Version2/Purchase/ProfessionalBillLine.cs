using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    public class ProfessionalBillLine : BillLine
    {
        public DateTime? Date { get; set; }
        public AccountLink Account { get; set; }
    }
}