using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYOB.AccountRight.SDK.Contracts.Version2.Payroll;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// NotSet
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// Male
        /// </summary>
        Male = 1,

        /// <summary>
        /// Female
        /// </summary>
        Female = 2,
        
        /// <summary>
        /// Indeterminate
        /// </summary>
        Indeterminate = 3
    }

    /// <summary>
    /// Describes the Employment Basis
    /// </summary>
    public enum EmploymentBasis
    {
        /// <summary>
        /// Individual
        /// </summary>
        Individual = 0,

        /// <summary>
        /// Labour Hire
        /// </summary>
        LabourHire = 1,

        /// <summary>
        /// Other
        /// </summary>
        Other = 2,
    }

    /// <summary>
    /// Describes Employment Category
    /// </summary>
    public enum EmploymentCategory
    {
        /// <summary>
        /// Permanent
        /// </summary>
        Permanent = 0,

        /// <summary>
        /// Temporary
        /// </summary>
        Temporary = 1
    }

    /// <summary>
    /// Describes Employment Status
    /// </summary>
    public enum EmploymentStatus
    {
        /// <summary>
        /// Full Time
        /// </summary>
        FullTime = 0,
        
        /// <summary>
        /// Part Time
        /// </summary>
        PartTime = 1,

        /// <summary>
        /// Other
        /// </summary>
        Other = 2,

        /// <summary>
        /// Casual
        /// </summary>
        Casual = 3
    }

    /// <summary>
    /// Describes the means of delivering the pay slip
    /// </summary>
    public enum PaySlipDelivery
    {
        /// <summary>
        /// To be printed
        /// </summary>
        ToBePrinted = 0,

        /// <summary>
        /// To be emailed
        /// </summary>
        ToBeEmailed = 1,

        /// <summary>
        /// To be printed AND emailed
        /// </summary>
        ToBePrintedAndEmailed = 2,

        /// <summary>
        /// Already printed or sent
        /// </summary>
        AlreadyPrintedOrSent = 3,
    }

    /// <summary>
    /// Describes the Employment Pay Basis
    /// </summary>
    public enum EmploymentPayBasis
    {
        /// <summary>
        /// Salary
        /// </summary>
        Salary = 0,

        /// <summary>
        /// Hourly
        /// </summary>
        Hourly = 1
    }

    /// <summary>
    /// Describes the pay frequency
    /// </summary>
    public enum PayFrequency
    {
        /// <summary>
        /// Weekly
        /// </summary>
        Weekly = 0,

        /// <summary>
        /// Fortnightly
        /// </summary>
        Fortnightly = 1,

        /// <summary>
        /// Twice a month
        /// </summary>
        TwiceAMonth = 2,

        /// <summary>
        /// Monthly
        /// </summary>
        Monthly = 3
    }

    /// <summary>
    /// Describes the location of the <see cref="EmployeePayrollDetails" /> resource for an <see cref="Employee"/>
    /// </summary>
    public class EmployeePayrollDetailsLink : BaseLink
    {
    }

    /// <summary>
    /// Describes the EmployeePayrollDetails
    /// </summary>
    public class EmployeePayrollDetails : BaseEntity
    {
        /// <summary>
        /// Employee
        /// </summary>
        public EmployeeLink Employee { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Start date of employment
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Date of termination
        /// </summary>
        public DateTime? TerminationDate { get; set; }

        /// <summary>
        /// Employment Basis: Individual (Employee), LaborHire (e.g. Contractor), or Other
        /// </summary>
        public EmploymentBasis EmploymentBasis { get; set; }

        /// <summary>
        /// Employment category
        /// </summary>
        public EmploymentCategory EmploymentCategory { get; set; }

        /// <summary>
        /// Employment Status
        /// </summary>
        public EmploymentStatus EmploymentStatus { get; set; }

        /// <summary>
        /// Employment Classification
        /// </summary>
        public PayrollEmploymentClassificationLink EmploymentClassification { get; set; }

        /// <summary>
        /// Pay slip delivery options
        /// </summary>
        public PaySlipDelivery PaySlipDelivery { get; set; }

        /// <summary>
        /// Pay Slip Email
        /// </summary>
        public string PaySlipEmail { get; set; }

        /// <summary>
        /// All information about the Employee's wage is here: Annyal Salary, Pay Basis, Wages Catgories...etc.
        /// </summary>
        public EmployeeWageInfo Wage { get; set; }

        /// <summary>
        /// Details relating to the the employee's Supperannuation
        /// </summary>
        public EmployeeSuperannuationInfo Superannuation { get; set; }

        /// <summary>
        /// Entitlements
        /// </summary>
        public IEnumerable<EmployeeEntitlementInfo> Entitlements { get; set; }

        /// <summary>
        /// Deduction Categories
        /// </summary>
        public IEnumerable<PayrollCategoryLink> Deductions { get; set; }

        /// <summary>
        /// Expenses Categories
        /// </summary>
        public IEnumerable<PayrollCategoryLink> EmployerExpenses { get; set; }

        /// <summary>
        /// All information about the Employee's tax is here: TaxFileNumber, TaxTable...etc.
        /// </summary>
        public EmployeeTaxInfo Tax { get; set; }

        /// <summary>
        /// Time Billing Info
        /// </summary>
        public EmployeeTimeBillingInfo TimeBilling { get; set; }
    }
}
