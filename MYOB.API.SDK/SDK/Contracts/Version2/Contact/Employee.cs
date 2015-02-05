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

        /// <summary>
        /// The location of the <see cref="EmployeeStandardPay" /> resource for this <see cref="Employee"/> 
        /// </summary>
        /// <remarks>
        /// Only applicable for 2014.4 cloud and 2015.1 desktop where supported
        /// </remarks>
        public EmployeeStandardPayLink EmployeeStandardPay { get; set; }

    }

    /// <summary>
    /// Describes a link to the <see cref="EmployeePaymentDetails" /> resource if supported
    /// </summary>
    public class EmployeePaymentDetailsLink : BaseLink
    {
    }

    /// <summary>
    /// Describes a link to the <see cref="EmployeeStandardPay" /> resource if supported
    /// </summary>
    public class EmployeeStandardPayLink : BaseLink
    {
    }
}