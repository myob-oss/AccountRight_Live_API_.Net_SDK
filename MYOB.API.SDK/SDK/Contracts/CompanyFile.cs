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
        ///   Account Right Live product level of the CompanyFile
        /// </summary>
        public ProductLevel ProductLevel { get; set; }

        /// <summary>
        /// Uri of the resource
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Launcher Id can be used to open Online Company files from command line
        /// </summary>
        public Guid? LauncherId { get; set; }
		
        /// <summary>
        /// Serial Number of Company file
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        public String Country { get; set; }
		
		/// <summary>
        /// UIAccessFlags
        /// </summary>
        public int UIAccessFlags { get; set; }

        /// <summary>
        /// Subscription Details of Company file
        /// </summary>
        public Subscription Subscription { get; set; }
    }
}
