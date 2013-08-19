using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Communication
{
    internal class ApiRequestHandler : BaseRequestHandler
    {
        public static Uri ApiRequestUri = new Uri("https://api.myob.com/accountright");
        private readonly OAuthTokens _oauth;
        private readonly IApiConfiguration _configuration;
        private readonly ICompanyFileCredentials _credentials;

        public ApiRequestHandler(IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null)
        {
            _oauth = oauth;
            _configuration = configuration;
            _credentials = credentials;
        }

        public void Get<T>(WebRequest request, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError) where T : class
        {
            SetStandardHeaders(request, _credentials.Maybe(_ => _.Username), _credentials.Maybe(_ => _.Password));
            request.BeginGetResponse(HandleResponseCallback<RequestContext<string, T>, string, T>,
                                     new RequestContext<string, T>
                                         {
                                             Request = request,
                                             OnComplete = (code, s, entity) => onComplete(code, entity),
                                             OnError = onError,
                                         });
        }

        public void Delete(WebRequest request, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError) 
        {
            SetStandardHeaders(request, _credentials.Maybe(_ => _.Username), _credentials.Maybe(_ => _.Password));
            request.Method = "DELETE";
            request.BeginGetResponse(HandleResponseCallback<RequestContext<string, string>, string, string>,
                                     new RequestContext<string, string>
                                     {
                                         Request = request,
                                         OnComplete = (code, s, entity) => onComplete(code),
                                         OnError = onError,
                                     });
        }

        public void Put<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
        {
            SetStandardHeaders(request, _credentials.Maybe(_ => _.Username), _credentials.Maybe(_ => _.Password));
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.BeginGetRequestStream(HandleRequestCallback<T>,
                                     new RequestContext<T, string>
                                     {
                                         Body = entity.ToJson(),
                                         Request = request,
                                         OnComplete = (code, s, response) => onComplete(code, s),
                                         OnError = onError,
                                     });
        }

        public void Post<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
        {
            SetStandardHeaders(request, _credentials.Maybe(_ => _.Username), _credentials.Maybe(_ => _.Password));
            request.Method = "POST";
            request.ContentType = "application/json";
            request.BeginGetRequestStream(HandleRequestCallback<T>,
                                     new RequestContext<T, string>
                                     {
                                         Body = entity.ToJson(),
                                         Request = request,
                                         OnComplete = (code, s, response) => onComplete(code, s),
                                         OnError = onError,
                                     });
        }

        private static void HandleRequestCallback<T>(IAsyncResult asynchronousResult)
        {
            var requestData = (RequestContext<T, string>)asynchronousResult.AsyncState;

            var request = requestData.Request;
            using (var requestStream = request.EndGetRequestStream(asynchronousResult))
            {
                using (var sw = new StreamWriter(requestStream))
                {
                    sw.Write(requestData.Body);
                }
            }

            request.BeginGetResponse(HandleResponseCallback<RequestContext<T, string>, T, string>, requestData);
        }

        private void SetStandardHeaders(WebRequest request, string username = null, string password = null)
        {
            request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", _oauth.Maybe(_ => _.AccessToken, string.Empty));
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            request.Headers["x-myobapi-key"] = _configuration.ClientId;
            request.Headers["x-myobapi-version"] = "v2";
            request.Headers["x-myobapi-cftoken"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username.Maybe(_ => _, string.Empty), password.Maybe(_ => _, string.Empty))));
        }
    }
}
