using Newtonsoft.Json;

namespace MYOB.AccountRight.SDK.Contracts
{
    interface IETagSupport
    {
        /// <summary>
        /// Returns the ETag from the HTTP response header
        /// </summary>
        [JsonIgnore]
        string ETag { get; set; }
    }
}
