namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    public class LinkedAccount : BaseEntity
    {
        public AccountLink Account { get; set; }
        public string Description { get; set; }
    }
}