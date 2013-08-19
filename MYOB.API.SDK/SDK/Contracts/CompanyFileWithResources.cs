using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// The full CompanyFile resource with available resources
    /// </summary>
    public class CompanyFileWithResources
    {
        /// <summary>
        /// The CompanyFile details
        /// </summary>
        public CompanyFile CompanyFile { get; set; }

        /// <summary>
        /// The resources available to this company file
        /// </summary>
        public IList<Uri> Resources { get; set; }
    }
}