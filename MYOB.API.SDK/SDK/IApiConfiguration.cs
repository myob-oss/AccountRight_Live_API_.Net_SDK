#if !PORTABLE
using System.Net.Cache;
#endif

namespace MYOB.AccountRight.SDK
{

    /// <summary>
    /// An interface for the API configuration
    /// </summary>
    public interface IApiConfiguration
    {
        /// <summary>
        /// The clientId
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// The clientSecret
        /// </summary>
        string ClientSecret { get; }

        /// <summary>
        /// The application redirectUrl, for desktop this is normally set to 'http://desktop'
        /// </summary>
        string RedirectUrl { get; }

        /// <summary>
        /// The api base url, for network mode this may be something like http://localhost:8080/accountright
        /// </summary>
        string ApiBaseUrl { get; }

        /// <summary>
        /// The username for password flow
        /// </summary>
        string AuthUsername { get;  }

        /// <summary>
        /// The password for password flow
        /// </summary>
        string AuthPassword { get;  }
        /// <summary>
        /// The api for password flow
        /// </summary>
        string AuthApiKey { get; }

#if !PORTABLE
        /// <summary>
        /// Gets or sets the cache policy for all requests
        /// </summary>
        RequestCachePolicy RequestCachePolicy { get; set; }
#endif

        /// <summary>
        /// Should the returned entities have the link Uris populated
        /// </summary>
        bool GenerateUris { get; }
    }
}