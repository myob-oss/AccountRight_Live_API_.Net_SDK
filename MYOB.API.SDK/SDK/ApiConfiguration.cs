﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYOB.AccountRight.SDK.Contracts.Version2;

#if !PORTABLE
using System.Net.Cache;
using System.Net;
#endif


namespace MYOB.AccountRight.SDK
{

    /// <summary>
    /// A simple container to hold basic API configuration
    /// </summary>
    /// <remarks>
    /// Enter your application client id and secret here
    /// 
    /// https://my.myob.com.au/Bd/pages/DevAppList.aspx
    /// </remarks>>
    public class ApiConfiguration : IApiConfiguration
    {

#if !PORTABLE
        static ApiConfiguration()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolTypeExtensions.Tls11 | SecurityProtocolTypeExtensions.Tls12;
        }
#endif

        /// <summary>
        /// Initializes an instance of the ApiConfiguration class (usually used for cloud mode)
        /// </summary>
        /// <param name="clientId">The client id (OAuth related)</param>
        /// <param name="clientSecret">The client id (OAuth related)</param>
        /// <param name="redirectUrl">The redirect uri for the application (OAuth related)</param>
        /// <param name="apiBaseUrl">The AccountRight API endpoint, defaults to 'https://api.myob.com/accountright'</param>
        /// <param name="generateUris">Should the returned entities have the <see cref="BaseEntity.URI"/> and <see cref="BaseLink.URI"/> fields populated</param>
        public ApiConfiguration(string clientId, string clientSecret, string redirectUrl, string apiBaseUrl = "https://api.myob.com/accountright", bool generateUris = true, string apiKey = null)
        {
            ApiBaseUrl = apiBaseUrl;
            ClientId = clientId;
            AuthApiKey = apiKey ?? clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
            GenerateUris = generateUris;
        }

        /// <summary>
        /// Initializes an instance of the ApiConfiguration class (usually used for network mode)
        /// </summary>
        /// <param name="apiBaseUrl"></param>
        public ApiConfiguration(string apiBaseUrl) : this(null, null, null, apiBaseUrl)
        {}

        /// <summary>
        /// The client id (OAuth related)
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// The client secret (OAuth related)
        /// </summary>
        public string ClientSecret { get; private set; }

        /// <summary>
        /// The redirect uri for the application (OAuth related)
        /// </summary>
        public string RedirectUrl { get; private set; }

        /// <summary>
        /// The AccountRight API endpoint, defaults to 'https://api.myob.com/accountright'
        /// </summary>
        public string ApiBaseUrl { get; private set; }

        /// <summary>
        /// Should the returned entities have the <see cref="BaseEntity.URI"/> and <see cref="BaseLink.URI"/> fields populated
        /// </summary>
        public bool GenerateUris { get; private set; }

        /// <summary>
        /// The username for password flow
        /// </summary>
        public string AuthUsername { get; }

        /// <summary>
        /// The password for password flow
        /// </summary>
        public string AuthPassword { get; }

        /// <summary>
        /// The Api key used for making api request
        /// </summary>
        public string AuthApiKey { get; }

#if !PORTABLE
        /// <summary>
        /// Gets or sets the cache policy for all requests
        /// </summary>
        public RequestCachePolicy RequestCachePolicy { get; set; } 
#endif
    }

    /// <summary>
    /// A simple container to hold basic company file credentials (not OAuth)
    /// </summary>
    public class CompanyFileCredentials : ICompanyFileCredentials
    {
        /// <summary>
        /// Initializes an instance of the CompanyFileCredentials class
        /// </summary>
        /// <param name="username">The company file username</param>
        /// <param name="password">The company file password</param>
        public CompanyFileCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// The company file username
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The company file password
        /// </summary>
        public string Password { get; private set; }
    }
}
