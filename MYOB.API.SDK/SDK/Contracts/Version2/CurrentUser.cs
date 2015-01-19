using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// describes the Current User resource
    /// </summary>
    public class CurrentUser
    {
        /// <summary>
        /// Contains the available UserAccess permissions for the current user
        /// </summary>
        public IEnumerable<UserAccess> UserAccess { get; set; }
    }
}