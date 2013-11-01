namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Describes the different term payment types
    /// </summary>
    public enum TermsPaymentType
    {
        /// <summary>
        /// Cash on delivery
        /// </summary>
        CashOnDelivery = 0,

        /// <summary>
        /// Pre-paid
        /// </summary>
        Prepaid,

        /// <summary>
        /// In a given number of days
        /// </summary>
        InAGivenNumberOfDays,

        /// <summary>
        /// on a particular day of the month i.e. 8th
        /// </summary>
        OnADayOfTheMonth,

        /// <summary>
        /// Number of days after the end of the month
        /// </summary>
        NumberOfDaysAfterEOM,

        /// <summary>
        /// The day of the month after the end of the month
        /// </summary>
        DayOfMonthAfterEOM
    }
}