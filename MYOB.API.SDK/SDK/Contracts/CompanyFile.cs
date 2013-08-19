using System;
using System.Runtime.Serialization;

namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    ///   CompanyFile
    /// </summary>
    public class CompanyFile
    {
        /// <summary>
        ///   The CompanyFile Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///   CompanyFile Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CompanyFile Library full path (including file name).
        /// </summary>
        public string LibraryPath { get; set; }

        /// <summary>
        ///   Account Right Live product version compatible with this CompanyFile
        /// </summary>
        public string ProductVersion { get; set; }

        /// <summary>
        /// Uri of the resource
        /// </summary>
        public Uri Uri { get; set; }
    }
}
