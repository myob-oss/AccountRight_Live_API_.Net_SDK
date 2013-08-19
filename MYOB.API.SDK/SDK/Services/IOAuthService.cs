using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IOAuthService
    {
        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Asynchronous)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void GetTokens(string code, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        OAuthTokens GetTokens(string code);

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Asynchronous)
        /// </summary>
        /// <param name="oauthTokens"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void RenewTokens(OAuthTokens oauthTokens, Action<HttpStatusCode, OAuthTokens> onComplete,Action<Uri, Exception> onError);

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="oauthTokens"></param>
        /// <returns></returns>
        OAuthTokens RenewTokens(OAuthTokens oauthTokens);
    }
}