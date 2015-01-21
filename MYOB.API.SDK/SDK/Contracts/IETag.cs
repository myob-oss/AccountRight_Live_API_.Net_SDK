using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB.AccountRight.SDK.Contracts
{
    interface IETag
    {
        /// <summary>
        /// Returns the ETag from the HTTP response header
        /// </summary>
        [JsonIgnore]
        string ETag { get; set; }
    }
}
