using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;
using PCLWebUtility;

namespace MYOB.AccountRight.SDK.Communication
{
    internal class OAuthRequestHandler : BaseRequestHandler
    {
        private readonly IApiConfiguration _configuration;

        /// <summary>
        /// https://secure.myob.com/oauth2/v1/authorize
        /// </summary>
        public static Uri OAuthRequestUri = new Uri("https://secure.myob.com/oauth2/v1/authorize");

        public OAuthRequestHandler(IApiConfiguration configuration)
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
            var data = string.Format("client_id={0}&client_secret={1}&redirect_uri={2}&scope=CompanyFile&code={3}&grant_type=authorization_code",
                                     _configuration.ClientId, _configuration.ClientSecret, WebUtility.UrlEncode(_configuration.RedirectUrl), code);

            BeginRequest(request, (statusCode, s, response) => onComplete(statusCode, response), onError, data);
        }

        /// <summary>
        /// Renew the OAuth tokens
        /// </summary>
        /// <param name="request"></param>
        /// <param name="oAuthResponse">The current OAuth response object</param>
        /// <param name="onComplete">The action to call when the new tokens have been retrieved</param>
        /// <param name="onError">The action to call on an error</param>
        public void RenewOAuthTokens(WebRequest request, OAuthTokens oAuthResponse, Action<HttpStatusCode, OAuthTokens> onComplete, Action<Uri, Exception> onError)
        {
            var data = string.Format("client_id={0}&client_secret={1}&refresh_token={2}&grant_type=refresh_token",
                                        _configuration.ClientId, _configuration.ClientSecret, oAuthResponse.RefreshToken);

            BeginRequest(request, (statusCode, s, response) => onComplete(statusCode, response), onError, data);
        }

        private static void BeginRequest(WebRequest request, Action<HttpStatusCode, string, OAuthTokens> onComplete, Action<Uri, Exception> onError, string data)
        {
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(HandleRequestCallback,
                                           new RequestContext<string, OAuthTokens>
                                           {
                                               Body = data,
                                               Request = request,
                                               OnComplete = onComplete,
                                               OnError = onError
                                           });
        }

        private static void HandleRequestCallback(IAsyncResult asynchronousResult)
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
