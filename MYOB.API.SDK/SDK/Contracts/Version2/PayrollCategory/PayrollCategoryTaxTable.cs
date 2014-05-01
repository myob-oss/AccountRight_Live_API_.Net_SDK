using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the PayrollCategoryTaxTable
    /// </summary>
    public class PayrollCategoryTaxTable : BaseEntity
    {
        /// <summary>
        /// Name of the Tax Table
        /// </summary>
        public string Name { get; set; }
    }
}
