using System;
using System.Runtime.Serialization;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Commonly shared properties for main entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique account identifier in the form of a guid.
        /// </summary>
        /// <remarks>
        /// ONLY required for updating an existing account. <br/>
        /// NOT required when creating a new account.
        /// </remarks>
        public Guid UID { get; set; }

        /// <summary>
        /// The location where this entity can be retrieved. (Read only)
        /// </summary>
        public Uri URI { get; set; }

        /// <summary>
        /// A number that can be used for change control but does not preserve a date or a time. <br/>
        /// </summary>
        /// <remarks>
        /// ONLY required for updating an existing account. <br/>
        /// NOT required when creating a new account. 
        /// </remarks>
        public string RowVersion { get; set; }

        /// <summary>
        /// If supported then the time the entity was created, or a default value if the database was upgraded and the time of creating was unknown and cannot be determined. (Read only)
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// If supported then the time the entity was last modified, or a default value if the database was upgraded and the time of last modification was unknown and cannot be determined. (Read only)
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}