using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Payroll
{
    /// <summary>
    /// Includes the employee payment summary
    /// </summary>
    public class EmployeePaymentSummary
    {
        /// <summary>
        /// Original or Ameneded payment summary
        /// </summary>
        public PaymentSummaryStatus Status { get; set; }

        /// <summary>
        /// payroll year of the payment summary
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// links to PDFs of payment summary
        /// </summary>
        public List<EmployeePaymentSummaryTypeLink> Types { get; set; }
    }

    /// <summary>
    /// Payment summary type
    /// </summary>
    public enum EmployeePaymentSummaryType
    {
        /// <summary>
        /// Individual
        /// </summary>
        INB,
        /// <summary>
        /// Termination
        /// </summary>
        ETP,
        /// <summary>
        /// Labor Hire
        /// </summary>
        LH
    }

    /// <summary>
    /// Payment Summary Status
    /// </summary>
    public enum PaymentSummaryStatus
    {
        /// <summary>
        /// Original
        /// </summary>
        Original,
        /// <summary>
        /// Amended
        /// </summary>
        Amended
    }
}