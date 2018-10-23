using System;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling
{
    /// <summary>
    /// Describes the base ActivitySlip
    /// </summary>
    public class ActivitySlip : BaseEntity
    {
        /// <summary>
        /// Construct an <see cref="ActivitySlip"/> object
        /// </summary>
        public ActivitySlip()
        {
        }
        
        /// <summary>
        /// The DisplayID associated with the activity slip
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// The Date the Activity was performed
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// The Employee or Supplier that the Activity Slip originates from
        /// </summary>
        public ContactLink Provider { get; set; }
        
        /// <summary>
        /// The Customer that the Activity was performed for
        /// </summary>
        public CustomerLink Customer { get; set; }
        
        /// <summary>
        /// The Activity performed on the Activity Slip
        /// </summary>
        public ActivityLink Activity { get; set; }
        
        /// <summary>
        /// The Job associated with the Activity Slip
        /// </summary>
        public JobLink Job { get; set; }
        
        /// <summary>
        /// The number of (time) units that the Activity will be billed for
        /// </summary>
        public decimal? UnitCount { get; set; }
        
        /// <summary>
        /// The rate that the Activity will be billed at on this Activity Slip
        /// </summary>
        public decimal? Rate { get; set; }
        
        /// <summary>
        /// The Adjustment of how much to bill the customer for in Currency
        /// </summary>
        public decimal? AdjustmentAmount { get; set; }
        
        /// <summary>
        /// The amount of Currency already billed
        /// </summary>
        public decimal? AlreadyBilledAmount { get; set; }
        
        /// <summary>
        /// The Adjustment of how much to bill the customer for in Billing Units
        /// </summary>
        public decimal AdjustmentCount { get; set; }
        
        /// <summary>
        /// The amount of Billing Units already billed
        /// </summary>
        public decimal AlreadyBilledCount { get; set; }
        
        /// <summary>
        /// Any notes associated with this Activity Slip
        /// </summary>
        public string Notes { get; set; }
        
        /// <summary>
        /// The description of the number of hours the Employee spent on this date for each Payroll Category or Activity
        /// </summary>
        public string StartStopDescription { get; set; }
        
        /// <summary>
        /// The exact time this Activity was started
        /// </summary>
        public DateTime? StartTime { get; set; }
        
        /// <summary>
        /// The exact time the Activity was finished
        /// </summary>
        public DateTime? EndTime { get; set; }
        
        /// <summary>
        /// The Elapsed Time for the Activity in Seconds
        /// </summary>
        public int? ElapsedTime { get; set; }
        
        /// <summary>
        /// The Payroll Category that should be assigned to this Activity Slip
        /// </summary>
        public PayrollCategoryLink HourlySalaryPayrollCategory { get; set; }
        
        /// <summary>
        /// The Amount already paid to the Employee for this Activity Slip
        /// </summary>
        public decimal PaidToEmployeeAmount { get; set; }
    }

}