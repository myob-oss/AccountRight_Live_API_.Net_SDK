namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes the Account Register resource
    /// </summary>
    public class AccountRegister : BaseEntity
    {
        /// <summary>
        /// Number of the Account (Read Only)
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Activity
        /// </summary>
        public decimal Activity { get; set; }

        /// <summary>
        /// Adjustment
        /// </summary>
        public decimal Adjustment { get; set; }

        /// <summary>
        /// Activity13Period
        /// </summary>
        public decimal YearEndActivity { get; set; }

        /// <summary>
        /// Adjustment13Period
        /// </summary>
        public decimal YearEndAdjustment { get; set; }

        /// <summary>
        /// UnitCount
        /// </summary>
        public decimal? UnitCount { get; set; }
    }
}