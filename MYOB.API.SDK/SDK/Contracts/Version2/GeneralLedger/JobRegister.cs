namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes a JobRegister resource (job profit centres)
    /// </summary>
    public class JobRegister : BaseEntity
    {
        /// <summary>
        /// A link to a <see cref="Job"/> resource
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// A line to an <see cref="Account"/> resource
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