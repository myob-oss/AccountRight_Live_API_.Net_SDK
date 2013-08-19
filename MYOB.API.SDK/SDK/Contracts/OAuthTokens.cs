using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace MYOB.AccountRight.SDK.Contracts
{
    public class OAuthTokens
    {
        public OAuthTokens()
        {
            ReceivedTime = DateTime.UtcNow;
        }

        public bool HasExpired
        {
            get
            {
                // refresh if we are within one minutes below the actual expiry time
                return (ReceivedTime + TimeSpan.FromSeconds(ExpiresIn - 60)) < DateTime.UtcNow;
            }
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// This is used to calculate the token expiration
        /// </summary>
        public DateTime ReceivedTime { get; set; }
    }
}
