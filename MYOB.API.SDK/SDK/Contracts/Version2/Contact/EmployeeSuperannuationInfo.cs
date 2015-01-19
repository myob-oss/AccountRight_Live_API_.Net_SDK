using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Employee Superannuation Info
    /// </summary>
    public class EmployeeSuperannuationInfo
    {
        /// <summary>
        /// SuperannationFund link
        /// </summary>
        public SuperannuationFundLink SuperannuationFund { get; set; }

        /// <summary>
        /// Employee Superannation Membership Number
        /// </summary>
        public string EmployeeMembershipNumber { get; set; }

        /// <summary>
        /// Superannation Categories
        /// </summary>
        public IEnumerable<PayrollCategoryLink> SuperannuationCategories { get; set; }

    }
}
