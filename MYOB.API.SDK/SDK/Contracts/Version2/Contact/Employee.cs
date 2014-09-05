namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes an Employee resource
    /// </summary>
    public class Employee : Contact
    {
        /// <summary>
        /// The location of the <see cref="EmployeePayrollDetails" /> resource for this <see cref="Employee"/> 
        /// </summary>
        /// <remarks>
        /// Only applicable for AU AccountRight (Plus and above) where Payroll has been configured 
        /// </remarks>
        public EmployeePayrollDetailsLink EmployeePayrollDetails { get; set; }

        /// <summary>
        /// The location of the <see cref="EmployeePaymentDetails" /> resource for this <see cref="Employee"/> 
        /// </summary>
        /// <remarks>
        /// Only applicable for 2014.3 cloud and 2014.4 desktop where supported
        /// </remarks>
        public EmployeePaymentDetailsLink EmployeePaymentDetails { get; set; }

    }

    /// <summary>
    /// Describes a link to the employee payment details if supported
    /// </summary>
    public class EmployeePaymentDetailsLink : BaseLink
    {
    }
}