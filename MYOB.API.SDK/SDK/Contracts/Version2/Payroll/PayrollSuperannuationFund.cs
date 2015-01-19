namespace MYOB.AccountRight.SDK.Contracts.Version2.Payroll
{
    using System;

    /// <summary>
    /// Superannuation fund
    /// </summary>
    public class PayrollSuperannuationFund
    {
        /// <summary>
        /// Unique id of the superannuation fund
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// PayrollSuperannuationFund Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Employer Membership Number
        /// </summary>
        public string EmployerMembershipNumber { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Rowversion
        /// </summary>
        public string Rowversion { get; set; }

        /// <summary>
        /// URI
        /// </summary>
        public Uri URI { get; set; }
    }
}
