using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the Employee Standard Pay
    /// </summary>
    public class EmployeeStandardPay : BaseEntity
    {
        /// <summary>
        /// Employee
        /// </summary>
        public EmployeeLink Employee { get; set; }

        /// <summary>
        /// Employee Payroll Details
        /// </summary>
        public EmployeePayrollDetailsLink EmployeePayrollDetails { get; set; }

        /// <summary>
        /// PayFrequency
        /// </summary>
        public PayFrequency PayFrequency { get; set; }

        /// <summary>
        /// Hours per pay frequency
        /// </summary>
        public decimal HoursPerPayFrequency { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// Memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Payroll categories
        /// </summary>
        public EmployeeStandardPayCategory[] PayrollCategories { get; set; }

    }

    /// <summary>
    /// Payroll Categories in employee standard pay 
    /// </summary>
    public class EmployeeStandardPayCategory
    {
        /// <summary>
        /// Payroll category
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// Hours
        /// </summary>
        public decimal? Hours { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Is Hours/Amount calculated or user enter
        /// </summary>
        public bool IsCalculated { get; set; }

        /// <summary>
        /// Job
        /// </summary>
        public JobLink Job { get; set; }
    }
}
