using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// Get and renew the OAuth tokens required to access the cloud based API
    /// </summary>
    public sealed class OAuthService : IOAuthService
    {
        private readonly IApiConfiguration _configuration;
        private readonly IWebRequestFactory _factory;

        /// <summary>
        /// Instantiate with OAuth configuration 
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="factory">A custom IWebRequestFactory implementation, defaults to WebRequestFactory if not supplied.</param>
        public OAuthService(IApiConfiguration configuration, IWebRequestFactory factory = null)
        {
            _configuration = configuration;
            this._factory = factory ?? new WebRequestFactory(configuration);
        }

        internal IWebRequestFactory Factory
        {
            get
            {
                return this._factory;
            }
        }

        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Delegate)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void GetTokens(string code, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError)
        {
            var handler = new OAuthRequestHandler(_configuration);
            var request = this.Factory.Create(OAuthRequestHandler.OAuthRequestUri);
            handler.GetOAuthTokens(request, code, onComplete, onError);
        }

        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <returns>The tokens that are required to access the user's company files</returns>
        public OAuthTokens GetTokens(string code)
        {
            var wait = new ManualResetEvent(false);
            OAuthTokens oauthTokens = null;
            Exception ex = null;
            var requestUri = default(Uri);

            GetTokens(code,
                (statusCode, tokens) =>
                    {
                        oauthTokens = tokens;
                        wait.Set();
                    },
                (uri, exception) =>
                    {
                        requestUri = uri;
                        ex = exception;
                        wait.Set();
                    });

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }

            return oauthTokens;
        }

#if ASYNC
        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <returns>The tokens that are required to access the user's company files</returns>
        public Task<OAuthTokens> GetTokensAsync(string code)
        {
            return this.GetTokensAsync(code, CancellationToken.None);
        } 

        /// <summary>
        /// Get the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="code">The code received after the user has given the application permission to access their company files</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The tokens that are required to access the user's company files</returns>
        async public Task<OAuthTokens> GetTokensAsync(string code, CancellationToken cancellationToken)
        {
            var handler = new OAuthRequestHandler(_configuration);
            var request = this.Factory.Create(OAuthRequestHandler.OAuthRequestUri);
            var tokens = await handler.GetOAuthTokensAsync(request, code, cancellationToken);
            return tokens.Item2;
        } 
#endif

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Delegate)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void RenewTokens(OAuthTokens oauthTokens, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError)
        {
            var handler = new OAuthRequestHandler(_configuration);
            var request = this.Factory.Create(OAuthRequestHandler.OAuthRequestUri);
            handler.RenewOAuthTokens(request, oauthTokens, onComplete, onError);
        }

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <returns></returns>
        public OAuthTokens RenewTokens(OAuthTokens oauthTokens)
        {
            var wait = new ManualResetEvent(false);
            OAuthTokens newTokens = null;
            Exception ex = null;
            var requestUri = default(Uri);

            RenewTokens(
                oauthTokens,
                (statusCode, tokens) =>
                    {
                        newTokens = tokens;
                        wait.Set();
                    },
                (uri, exception) =>
                    {
                        requestUri = uri;
                        ex = exception;
                        wait.Set();
                    });

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }

            return newTokens;
        }

#if ASYNC
        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <returns></returns>
        public Task<OAuthTokens> RenewTokensAsync(OAuthTokens oauthTokens)
        {
            return this.RenewTokensAsync(oauthTokens, CancellationToken.None);
        } 

        /// <summary>
        /// Renew the OAuth tokens required to access the cloud based API (Synchronous)
        /// </summary>
        /// <param name="oauthTokens">The tokens that are required to access the user's company files</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        async public Task<OAuthTokens> RenewTokensAsync(OAuthTokens oauthTokens, CancellationToken cancellationToken)
        {
            var handler = new OAuthRequestHandler(_configuration);
            var request = this.Factory.Create(OAuthRequestHandler.OAuthRequestUri);
            var tokens = await handler.RenewOAuthTokensAsync(request, oauthTokens, cancellationToken);
            return tokens.Item2;
        } 
#endif
    }

}
