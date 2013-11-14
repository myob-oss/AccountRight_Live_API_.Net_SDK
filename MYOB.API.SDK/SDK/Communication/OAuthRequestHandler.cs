using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Communication
{
    internal class OAuthRequestHandler : BaseRequestHandler
    {
        /// <summary>
        /// https://secure.myob.com/oauth2/v1/authorize
        /// </summary>
        public static Uri OAuthRequestUri = new Uri("https://secure.myob.com/oauth2/v1/authorize");

        private readonly IApiConfiguration _configuration;

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
        async public Task<Tuple<HttpStatusCode, OAuthTokens>> GetOAuthTokensAsync(WebRequest request, string code)
        {
            var data = BuildRequestTokenData(code);

            var get = await BeginRequestAsync(request, data);
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

        private void ConfigureRequest(WebRequest request)
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
        async public Task<Tuple<HttpStatusCode, OAuthTokens>> RenewOAuthTokensAsync(WebRequest request, OAuthTokens oAuthResponse)
        {
            var data = BuildRenewTokenData(oAuthResponse);

            ConfigureRequest(request);
            var get = await BeginRequestAsync(request, data);
            return new Tuple<HttpStatusCode, OAuthTokens>(get.Item1, get.Item3);
        }
#endif

        private void BeginRequest(WebRequest request, Action<HttpStatusCode, string, OAuthTokens> onComplete, Action<Uri, Exception> onError, string data)
        {
            request.BeginGetRequestStream(HandleRequestCallback,
                                           new RequestContext<string, OAuthTokens>
                                           {
                                               Body = data,
                                               Request = request,
                                               OnComplete = onComplete,
                                               OnError = onError
                                           });
        }

#if ASYNC
        async private Task<Tuple<HttpStatusCode, string, OAuthTokens>> BeginRequestAsync(WebRequest request, string data)
        {
            return await GetResponseTask<OAuthTokens>(await GetRequestStreamTask<string>(request, data));
        }

        private static async Task<WebRequest> GetRequestStreamTask<T>(WebRequest request, string data)
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
            var requestData = (RequestContext<string, OAuthTokens>)asynchronousResult.AsyncState;

            var request = requestData.Request;
            using (var requestStream = request.EndGetRequestStream(asynchronousResult))
            {
                using (var sw = new StreamWriter(requestStream))
                {
                    sw.Write(requestData.Body);
                }
            }

            request.BeginGetResponse(HandleResponseCallback<RequestContext<string, OAuthTokens>, string, OAuthTokens>, requestData);
        }
    }
}
