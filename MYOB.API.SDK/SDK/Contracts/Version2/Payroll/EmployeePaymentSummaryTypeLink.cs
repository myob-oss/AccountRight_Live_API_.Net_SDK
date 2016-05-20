namespace MYOB.AccountRight.SDK.Contracts.Version2.Payroll
{
    /// <summary>
    /// Payment Summary type 
    /// </summary>
    public class EmployeePaymentSummaryTypeLink : BaseLink
    {
        /// <summary>
        /// Indicatates the payment summary type
        /// </summary>
        public EmployeePaymentSummaryType Type { get; set; }
    }
}