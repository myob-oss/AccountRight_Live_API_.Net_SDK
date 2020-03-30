using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Describes a link to the <see cref="Location"/> resource
    /// </summary>
    public class LocationLink : BaseLink
    {
        /// <summary>
        /// Location Notes.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Name of the Location.
        /// </summary>
        public string Name { get; set; }
    }
}