using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Employment Entitlement Info
    /// </summary>
    public class EmployeeEntitlementInfo
    {
        /// <summary>
        /// Entitlement Category
        /// </summary>
        public PayrollCategoryLink EntitlementCategory { get; set; }

        /// <summary>
        /// Current entitlement is assigned
        /// </summary>
        public bool IsAssigned { get; set; }

        /// <summary>
        /// Carry Over
        /// </summary>
        public decimal CarryOver { get; set; }
    
        /// <summary>
        /// Year To Date
        /// </summary>
        public decimal YearToDate { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get; set; }
    }
}