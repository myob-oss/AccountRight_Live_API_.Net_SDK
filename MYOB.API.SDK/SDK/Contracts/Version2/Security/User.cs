namespace MYOB.AccountRight.SDK.Contracts.Version2.Security
{
    /// <summary>
    /// describes a user resource
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Simple constructor
        /// </summary>
        public User()
        {
            IsActive = true;
        }
        /// <summary>
        ///  the name of the role (read-only)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The associated mydotIdentity (Cloud-only)
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
        /// Is user active (defaults to true)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Should user be made an online administrator when creating user (POST) (read-only) (Cloud-only)
        /// </summary>
        public bool? IsOnlineAdministrator { get; set; }

        /// <summary>
        /// User should be invited using the supplied <see cref="MYDOTIdentity"/> (read-only) (Cloud-only)
        /// </summary>
        public bool? InviteUser { get; set; }

    }
}
