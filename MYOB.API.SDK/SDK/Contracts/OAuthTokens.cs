using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// The OAuth access and refesh tokens
    /// </summary>
    public class OAuthTokens
    {
        /// <summary>
        /// Initialise a token with Now as the ReceivedTime
        /// </summary>
        public OAuthTokens()
        {
            ReceivedTime = DateTime.UtcNow;
        }

        /// <summary>
        /// determine if the token has expired
        /// </summary>
        public bool HasExpired
        {
            get
            {
                // refresh if we are within one minutes below the actual expiry time
                return (ReceivedTime + TimeSpan.FromSeconds(ExpiresIn - 60)) < DateTime.UtcNow;
            }
        }

        /// <summary>
        /// The access_token field
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The token_type field
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// The refesh_token field
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The expires_in field (seconds)
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The requested scope e.g. CompanyFile
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// This is used to calculate the token expiration
        /// </summary>
        public DateTime ReceivedTime { get; set; }
    }
}
