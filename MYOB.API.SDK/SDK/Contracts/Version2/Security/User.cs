namespace MYOB.AccountRight.SDK.Contracts.Version2.Security
{
    /// <summary>
    /// describes a user resource
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        ///  the name of the role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The associated mydotIdentity
        /// </summary>
// ReSharper disable once InconsistentNaming
        public string MYDOTIdentity { get; set; }

        /// <summary>
        /// The Roles
        /// </summary>
        public RoleLink[] Roles { get; set; }

        /// <summary>
        /// Is user an advisor (read-only)
        /// </summary>
        public bool IsAdvisor { get; set; }

        /// <summary>
        /// Is user active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Should user be made an online administrator when creating user (POST)
        /// </summary>
        public bool? IsOnlineAdministrator { get; set; }
    }
}
