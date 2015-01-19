using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Describes a UserAccess resource
    /// </summary>
    public class UserAccess
    {
        /// <summary>
        /// Path to resource
        /// </summary>
        public string ResourcePath { get; set; }

        /// <summary>
        /// Contains the verbs the user may use against specified resource
        /// </summary>
        public IEnumerable<string> Access { get; set; }
    }
}
