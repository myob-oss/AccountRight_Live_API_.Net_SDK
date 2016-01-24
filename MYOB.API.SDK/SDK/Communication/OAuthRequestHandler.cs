using System;
using System.IO;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Communication
{
    /// <summary>
    /// The OAuth request handler, manages the OAuth token fetching and renewal
    /// </summary>
    public class OAuthRequestHandler : BaseRequestHandler
    {
        /// <summary>
        /// https://secure.myob.com/oauth2/v1/authorize
        /// </summary>
        public static readonly Uri OAuthRequestUri = new Uri("https://secure.myob.com/oauth2/v1/authorize");

        private readonly IApiConfiguration _configuration;

        /// <summary>
        /// Constructs an OAuth request handler
        /// </summary>
        /// <param name="configuration"></param>
        public OAuthRequestHandler(IApiConfiguration configuration) : base(new ApiRequestHelper())
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Start the process of getting the OAuth tokens using the code received from the authorization site
        /// </summary>
        /// <param name="request"></param>
        /// <param name="code">The code received from the authorization site</param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        public void GetOAuthTokens(WebRequest request, string code, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError)
        {
            var data = BuildRequestTokenData(code);
            ConfigureRequest(request);
            BeginRequest(request, (statusCode, s, response) => onComplete(statusCode, response), onError, data);
        }

        private string BuildRequestTokenData(string code)
        {
            var data = string.Format("client_id={0}&client_secret={1}&redirect_uri={2}&scope=CompanyFile&code={3}&grant_type=authorization_code",
                    _configuration.ClientId, _configuration.ClientSecret, Uri.EscapeDataString(_configuration.RedirectUrl), code);

            return data;
        }

#if ASYNC
        /// <summary>
        /// Start the process of getting the OAuth tokens using the code received from the authorization site
        /// </summary>
        /// <param name="request"></param>
        /// <param name="code">The code received from the authorization site</param>
        public Task<Tuple<HttpStatusCode, OAuthTokens>> GetOAuthTokensAsync(WebRequest request, string code)
        {
            return GetOAuthTokensAsync(request, code, CancellationToken.None);
        }

        /// <summary>
        /// Start the process of getting the OAuth tokens using the code received from the authorization site
        /// </summary>
        /// <param name="request"></param>
        /// <param name="code">The code received from the authorization site</param>
        /// <param name="cancellationToken"></param>
        async public Task<Tuple<HttpStatusCode, OAuthTokens>> GetOAuthTokensAsync(WebRequest request, string code, CancellationToken cancellationToken)
        {
            var data = BuildRequestTokenData(code);
            ConfigureRequest(request);
            var get = await BeginRequestAsync(request, data, cancellationToken);
            return new Tuple<HttpStatusCode, OAuthTokens>(get.Item1, get.Item3);
        }
#endif
        /// <summary>
        /// Renew the OAuth tokens
        /// </summary>
        /// <param name="request"></param>
        /// <param name="oAuthResponse">The current OAuth response object</param>
        /// <param name="onComplete">The action to call when the new tokens have been retrieved</param>
        /// <param name="onError">The action to call on an error</param>
        public void RenewOAuthTokens(WebRequest request, OAuthTokens oAuthResponse, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError)
        {
            var data = BuildRenewTokenData(oAuthResponse);
            ConfigureRequest(request);
            BeginRequest(request, (statusCode, s, response) => onComplete(statusCode, response), onError, data);
        }

        private string BuildRenewTokenData(OAuthTokens oAuthResponse)
        {
            var data = string.Format("client_id={0}&client_secret={1}&refresh_token={2}&grant_type=refresh_token",
                                     _configuration.ClientId, _configuration.ClientSecret, oAuthResponse.RefreshToken);
            return data;
        }

        private static void ConfigureRequest(WebRequest request)
        {
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
        }

#if ASYNC
        /// <summary>
        /// Renew the OAuth tokens
        /// </summary>
        /// <param name="request"></param>
        /// <param name="oAuthResponse">The current OAuth response object</param>
        public Task<Tuple<HttpStatusCode, OAuthTokens>> RenewOAuthTokensAsync(WebRequest request, OAuthTokens oAuthResponse)
        {
            return RenewOAuthTokensAsync(request, oAuthResponse, CancellationToken.None);
        }

        /// <summary>
        /// Renew the OAuth tokens
        /// </summary>
        /// <param name="request"></param>
        /// <param name="oAuthResponse">The current OAuth response object</param>
        /// <param name="cancellationToken"></param>
        async public Task<Tuple<HttpStatusCode, OAuthTokens>> RenewOAuthTokensAsync(WebRequest request, OAuthTokens oAuthResponse, CancellationToken cancellationToken)
        {
            var data = BuildRenewTokenData(oAuthResponse);
            ConfigureRequest(request);
            var get = await BeginRequestAsync(request, data, cancellationToken);
            return new Tuple<HttpStatusCode, OAuthTokens>(get.Item1, get.Item3);
        }
#endif

        private void BeginRequest(WebRequest request, Action<HttpStatusCode, string, OAuthTokens> onComplete, Action<Uri, Exception> onError, string data)
        {
            request.BeginGetRequestStream(HandleRequestCallback,
                                           new RequestContext<OAuthTokens>
                                           {
                                               Body = data,
                                               Request = request,
                                               OnComplete = onComplete,
                                               OnError = onError
                                           });
        }

#if ASYNC
        async private Task<Tuple<HttpStatusCode, string, OAuthTokens>> BeginRequestAsync(WebRequest request, string data, CancellationToken cancellationToken)
        {
            return await GetResponseTask<OAuthTokens>(await GetRequestStreamTask(request, data), cancellationToken);
        }

        private static async Task<WebRequest> GetRequestStreamTask(WebRequest request, string data)
        {
            using (var stream = await request.GetRequestStreamAsync())
            {
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(data);
                }
            }
            return request;
        }
#endif

        private void HandleRequestCallback(IAsyncResult asynchronousResult)
        {
            var requestData = (RequestContext<OAuthTokens>)asynchronousResult.AsyncState;

            var request = requestData.Request;
            using (var requestStream = request.EndGetRequestStream(asynchronousResult))
            {
                using (var sw = new StreamWriter(requestStream))
                {
                    sw.Write(requestData.Body);
                }
            }

            request.BeginGetResponse(HandleResponseCallback<RequestContext<OAuthTokens>, OAuthTokens>, requestData);
        }
    }
}
