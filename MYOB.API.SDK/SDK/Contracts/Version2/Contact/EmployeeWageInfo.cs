using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Employee Wage Info
    /// </summary>
    public class EmployeeWageInfo
    {
        /// <summary>
        /// Pay Basis
        /// </summary>
        public EmploymentPayBasis PayBasis { get; set; }

        /// <summary>
        /// Annual Salary
        /// </summary>
        public decimal AnnualSalary { get; set; }

        /// <summary>
        /// Hourly Rate
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        /// Pay Frequency
        /// </summary>
        public PayFrequency PayFrequency { get; set; }

        /// <summary>
        /// Hours In Weekly Pay Period
        /// </summary>
        public decimal HoursInWeeklyPayPeriod { get; set; }

        /// <summary>
        /// Wages Expense Account
        /// </summary>
        public AccountLink WagesExpenseAccount { get; set; }

        /// <summary>
        /// Wage Categories
        /// </summary>
        public IEnumerable<PayrollCategoryLink> WageCategories { get; set; }
    }
}