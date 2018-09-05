using MYOB.AccountRight.SDK.Contracts.Version2.Payroll;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the EmployeePaymentSummaryReport
    /// </summary>
    public class EmployeePaymentSummaryReport : BaseEntity
    {
        /// <summary>
        /// Employee
        /// </summary>
        public EmployeeLink Employee { get; set; }

        /// <summary>
        /// Employee payment summmary
        /// </summary>
        public EmployeePaymentSummary EmployeePaymentSummary { get; set; }
    }
}
