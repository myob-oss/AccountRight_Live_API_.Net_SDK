namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{

    /// <summary>
    /// Describes a CategoryRegister resource
    /// </summary>
    public class CategoryRegister 
    {
        /// <summary>
        /// A link to a Category resource
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// A link to an Account resource
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Financial year in which the activity was generated ie 2014.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Month in which the activity was generated ie December = 12.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Net activity within profit &amp; loss account or net movement within balance sheet accounts.
        /// </summary>
        public decimal Activity { get; set; }
        
        /// <summary>
        /// Net activity within profit &amp; loss account or net movement within balance sheet accounts for YearEndAdjustments.
        /// </summary>
        public decimal YearEndActivity { get; set; }
    }
}