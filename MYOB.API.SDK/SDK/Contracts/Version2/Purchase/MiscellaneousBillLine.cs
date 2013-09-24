using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    public class MiscellaneousBillLine : BillLine
    {
        public AccountLink Account { get; set; }
    }
}
