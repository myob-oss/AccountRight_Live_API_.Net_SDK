using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the tax PayrollCategory
    /// </summary>
    public class PayrollCategoryTax : PayrollCategory
    {
        /// <summary>
        /// The linked payable account
        /// </summary>
        public AccountLink PayableAccount { get; set; }

        /// <summary>
        /// The current tax table revision date, if loaded
        /// </summary>
        public DateTime? TaxTableRevisionDate { get; set; }
    }
}