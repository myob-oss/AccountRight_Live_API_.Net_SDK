using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// The deployed API version info
    /// </summary>
    public class VersionInfo
    {
        /// <summary>
        /// The build number of the deployed API
        /// </summary>
        public string Build { get; set; }

        /// <summary>
        /// A list of available resources supported by this API
        /// </summary>
        public IEnumerable<VersionMap> Resources { get; set; }
    }
}
