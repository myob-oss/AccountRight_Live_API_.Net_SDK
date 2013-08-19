namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// JobRegister
    /// </summary>
    public class JobRegister : BaseEntity
    {
        public JobLink Job { get; set; }
        public AccountLink Account { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Activity { get; set; }
        public decimal YearEndActivity { get; set; }
    }
}