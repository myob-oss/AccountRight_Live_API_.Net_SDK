using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Report.PayrollCategorySummary
{
    /// <summary>
    /// Includes payroll category breakups for a given period
    /// </summary>
    public class PayrollCategorySummary 
    {
        /// <summary>
        /// Start Date of the reporting period
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End Date of the reporting period
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Payroll Category with total amount breakdown
        /// </summary>
        public List<PayrollCategoryBreakdown> PayrollCategoryBreakdown { get; set; }

    }

    /// <summary>
    /// Breakdown of Payroll Category with total amount for a given period
    /// </summary>
    public class PayrollCategoryBreakdown
    {
        /// <summary>
        /// Total Amount in $
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Total hours
        /// </summary>
        public decimal? Hours { get; set; }

        /// <summary>
        /// Link to Payroll Category
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }
    }
}
