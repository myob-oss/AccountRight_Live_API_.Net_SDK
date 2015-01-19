using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Usage of Timesheet
    /// </summary>
    public enum TimesheetPreferenceUsage
    {
        /// <summary>
        /// Time billing and payroll
        /// </summary>
        TimeBillingAndPayroll,

        /// <summary>
        /// Payroll
        /// </summary>
        Payroll,
    }

    /// <summary>
    /// Timesheet preferent details
    /// </summary>
    public class CompanyTimesheetPreferences
    {
        /// <summary>
        /// What the Timesheet is used for
        /// </summary>
        public TimesheetPreferenceUsage UseTimesheetsFor { get; set; }

        /// <summary>
        /// The day the Timesheet week starts on
        /// </summary>
        public DayOfWeek WeekStartsOn { get; set; }
    }
}