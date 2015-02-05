using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Commonly shared properties for links to other entities
    /// </summary>
    public abstract class BaseLink
    {
        /// <summary>
        /// Unique identifier for the referenced entity.
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// The location where the referenced entity can be retrieved. (Read only)
        /// </summary>
        public Uri URI { get; set; }
    }
}