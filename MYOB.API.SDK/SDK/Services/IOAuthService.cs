using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// An interface that describes the available interactions with the OAuth server
    /// </summary>
    public interface IOAuthService
    {
        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Delegate)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void GetTokens(string code, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <returns>The tokens that are required to access the user's company files</returns>
        OAuthTokens GetTokens(string code);

#if ASYNC
        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Asynchronous)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <returns>The tokens that are required to access the user's company files</returns>
        Task<OAuthTokens> GetTokensAsync(string code); 

        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Asynchronous)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The tokens that are required to access the user's company files</returns>
        Task<OAuthTokens> GetTokensAsync(string code, CancellationToken cancellationToken); 
#endif

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Delegate)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void RenewTokens(OAuthTokens oauthTokens, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <returns></returns>
        OAuthTokens RenewTokens(OAuthTokens oauthTokens);

#if ASYNC
        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Asynchronous)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <returns></returns>
        Task<OAuthTokens> RenewTokensAsync(OAuthTokens oauthTokens); 

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Asynchronous)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OAuthTokens> RenewTokensAsync(OAuthTokens oauthTokens, CancellationToken cancellationToken); 
#endif
    }
}