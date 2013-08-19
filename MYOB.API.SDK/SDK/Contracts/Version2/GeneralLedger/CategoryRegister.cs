namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{

    /// <summary>
    /// CategoryRegister
    /// </summary>
    public class CategoryRegister 
    {
        public CategoryLink Category { get; set; }
        public AccountLink Account { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Activity { get; set; }
        public decimal YearEndActivity { get; set; }
    }
}