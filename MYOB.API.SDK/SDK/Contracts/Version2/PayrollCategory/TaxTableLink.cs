using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// A link to a PayrollCategory
    /// </summary>
    public class TaxTableLink : BaseLink
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
