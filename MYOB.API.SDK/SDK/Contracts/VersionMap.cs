namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// A resource description describing the path, version and applicable company file versions supported
    /// </summary>
    public class VersionMap
    {
        /// <summary>
        /// The resource path to use after the companyfile ID
        /// </summary>
        public string ResourcePath { get; set; }

        /// <summary>
        /// The version this resource is applicable to
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The company file version this resource is supported from
        /// </summary>
        public string FromProductVersion { get; set; }

        /// <summary>
        /// The company file version this resource is supported to
        /// </summary>
        public string ToProductVersion { get; set; }
        
        /// <summary>
        /// The comapny file version this resource for Mininum Product Level
        /// </summary>
        public ProductLevel MinimumProductLevel { get; set; }
    }
}