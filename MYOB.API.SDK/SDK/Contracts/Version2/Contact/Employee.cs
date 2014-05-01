namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes an Employyee resource
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
    }
}