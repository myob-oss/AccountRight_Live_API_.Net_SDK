using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Company Link
    /// </summary>
    public class CompanyLink
    {
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ABN or TFN
        /// </summary>
        public string ABNOrTFN { get; set; }

        /// <summary>
        /// The location where the referenced entity can be retrieved. (Read only)
        /// </summary>
        public Uri URI { get; set; }
    }
}
