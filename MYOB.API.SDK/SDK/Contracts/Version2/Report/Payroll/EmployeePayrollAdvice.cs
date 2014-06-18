using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Company;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Report.Payroll
{
    /// <summary>
    /// Describes the EmployeePayrollAdvice resource
    /// </summary>
    public class EmployeePayrollAdvice
    {
        /// <summary>
        /// The Employer
        /// </summary>
        public CompanyLink Employer { get; set; }

        /// <summary>
        /// The Employee
        /// </summary>
        public EmployeeLink Employee { get; set; }

        /// <summary>
        /// The Payment Date
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Pay Period Start
        /// </summary>
        public DateTime PayPeriodStartDate { get; set; }

        /// <summary>
        /// The Pay Period End
        /// </summary>
        public DateTime PayPeriodEndDate { get; set; }

        /// <summary>
        /// Pay Frequency 
        /// </summary>
        public PayFrequency PayFrequency { get; set; }

        /// <summary>
        /// Annual Salary
        /// </summary>
        public decimal AnnualSalary { get; set; }

        /// <summary>
        /// Gross Pay
        /// </summary>
        public decimal GrossPay { get; set; }

        /// <summary>
        /// Net Pay
        /// </summary>
        public decimal NetPay { get; set; }

        /// <summary>
        /// Hourly Rate
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        /// Cheque Number
        /// </summary>
        public string ChequeNumber { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Superannuation Fund Link
        /// </summary>
        public SuperannuationFundLink SuperannuationFund { get; set; }

        /// <summary>
        /// Employment Classification Link
        /// </summary>
        public PayrollEmploymentClassificationLink EmploymentClassification { get; set; }

        /// <summary>
        /// Payroll Advice Lines
        /// </summary>
        public IEnumerable<EmployeePayrollAdviceLine> Lines { get; set; }
    }

    /// <summary>
    /// Payroll Advice Line
    /// </summary>
    public class EmployeePayrollAdviceLine
    {
        /// <summary>
        /// Payroll Category Link
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// Hours
        /// </summary>
        public decimal? Hours { get; set; }

        /// <summary>
        ///  Calculation Rate
        /// </summary>
        public decimal? CalculationRate { get; set; }

        /// <summary>
        /// Payment Amount
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        ///  Year to Date Amount
        /// </summary>
        public decimal YearToDate { get; set; }
    }
}



