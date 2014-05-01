namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// EmployeeTimeBillingInfo
    /// </summary>
    public class EmployeeTimeBillingInfo
    {
        /// <summary>
        /// Employee Billing Rate Excluding Tax
        /// </summary>
        public decimal EmployeeBillingRateExcludingTax { get; set; }

        /// <summary>
        /// Cost Per Hour
        /// </summary>
        public decimal CostPerHour { get; set; }
    }
}