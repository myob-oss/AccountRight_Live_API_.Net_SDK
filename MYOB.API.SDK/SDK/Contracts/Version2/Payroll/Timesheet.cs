using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Payroll
{
    /// <summary>
    /// Describes the Timesheet resource
    /// </summary>
    public class Timesheet
    {
        /// <summary>
        /// The Employee
        /// </summary>
        public EmployeeLink Employee { get; set; }

        /// <summary>
        /// Timesheet Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Timesheet End Date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Timesheet Lines
        /// </summary>
        public IEnumerable<TimesheetLine> Lines { get; set; }

        /// <summary>
        /// Timesheet Uri
        /// </summary>
        public Uri Uri { get; set; }
    }

    /// <summary>
    ///  Describes the TimesheetLine
    /// </summary>
    public class TimesheetLine
    {
        /// <summary>
        /// The PayrollCategory
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The Job
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// The Activity
        /// </summary>
        public ActivityLink Activity { get; set; }

        /// <summary>
        /// The Customer
        /// </summary>
        public CustomerLink Customer { get; set; }

        /// <summary>
        /// The Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The day entries
        /// </summary>
        public IEnumerable<TimesheetEntry> Entries { get; set; }
    }

    /// <summary>
    /// Describes the TimesheetEntry
    /// </summary>
    public class TimesheetEntry
    {

        /// <summary>
        /// The Date
        /// </summary>
        public DateTime Date { get; set; }


        /// <summary>
        /// The Hours
        /// </summary>
        public decimal Hours { get; set; }


        /// <summary>
        /// Timesheet entry Processed state
        /// </summary>
        public bool Processed { get; set; }
    }
}



