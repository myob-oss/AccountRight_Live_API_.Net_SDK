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
#if COMPRESSION
using System.IO.Compression;
#else
using SharpCompress.Compressor;
using SharpCompress.Compressor.Deflate;
#endif

namespace MYOB.AccountRight.SDK.Communication
{
    internal class ApiRequestHandler : BaseRequestHandler
    {
        public static Uri ApiRequestUri = new Uri("https://api.myob.com/accountright");

        private readonly OAuthTokens _oauth;
        private readonly IApiConfiguration _configuration;
        private readonly ICompanyFileCredentials _credentials;

        public ApiRequestHandler(IApiConfiguration configuration, ICompanyFileCredentials credentials,
                                 OAuthTokens oauth = null)
            : base(new ApiRequestHelper())
        {
            _oauth = oauth;
            _configuration = configuration;
            _credentials = credentials;
        }

        public void Get<T>(WebRequest request, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError)
            where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.BeginGetResponse(HandleResponseCallback<RequestContext<string, T>, string, T>,
                                     new RequestContext<string, T>
                                         {
                                             Request = request,
                                             OnComplete = (code, s, entity) => onComplete(code, entity),
                                             OnError = onError,
                                         });
        }

#if ASYNC
        public async Task<Tuple<HttpStatusCode, T>> GetAsync<T>(WebRequest request) where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            var get = await GetResponseTask<T>(request);
            return new Tuple<HttpStatusCode, T>(get.Item1, get.Item3);
        }
#endif

        public void Delete(WebRequest request, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "DELETE";
            request.BeginGetResponse(HandleResponseCallback<RequestContext<string, string>, string, string>,
                                     new RequestContext<string, string>
                                         {
                                             Request = request,
                                             OnComplete = (code, s, entity) => onComplete(code),
                                             OnError = onError,
                                         });
        }

#if ASYNC
        public async Task DeleteAsync(WebRequest request)
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "DELETE";
            await GetResponseTask<string>(request);
        }
#endif

        public void Put<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete,
                           Action<Uri, Exception> onError)
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
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

#if ASYNC
        public async Task<string> PutAsync<T>(WebRequest request, T entity) where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var res = await GetRequestStreamTask(request, entity).ContinueWith(t => GetResponseTask<T>(t.Result));
            return res.Result.Item2;
        }
#endif

        public void Post<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete,
                            Action<Uri, Exception> onError)
            where T : class
        {
            Post<T, string>(request, entity, (code, s, response) => onComplete(code, s), onError);
        }

        public void Post<TRequest, TResponse>(WebRequest request, TRequest entity,
                                              Action<HttpStatusCode, string, TResponse> onComplete,
                                              Action<Uri, Exception> onError)
            where TResponse : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.BeginGetRequestStream(HandleRequestCallback<TRequest, TResponse>,
                                          new RequestContext<TRequest, TResponse>
                                              {
                                                  Body = entity.ToJson(),
                                                  Request = request,
                                                  OnComplete = onComplete,
                                                  OnError = onError,
                                              });
        }

#if ASYNC
        public async Task<string> PostAsync<T>(WebRequest request, T entity) where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "POST";
            request.ContentType = "application/json";
            var res = await GetRequestStreamTask(request, entity).ContinueWith(t => GetResponseTask<T>(t.Result));
            return res.Result.Item2;
        }

        public async Task<TResponseEntity> PostAsync<TRequestEntity, TResponseEntity>(WebRequest request,
                                                                                      TRequestEntity entity)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "POST";
            request.ContentType = "application/json";
            var res = await GetRequestStreamTask(request, entity).ContinueWith(t => GetResponseTask<TResponseEntity>(t.Result));
            return res.Result.Item3;
        }
#endif

#if ASYNC
        private static async Task<WebRequest> GetRequestStreamTask<T>(WebRequest request, T entity) where T : class
        {
            using (var stream = await request.GetRequestStreamAsync())
            {
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(entity.ToJson());
                }
            }
            return request;
        }
#endif

        private void HandleRequestCallback<T>(IAsyncResult asynchronousResult)
        {
            HandleRequestCallback<T, string>(asynchronousResult);
        }

        private void HandleRequestCallback<TRequestEntity, TResponseEntity>(IAsyncResult asynchronousResult)
            where TResponseEntity : class
        {
            var requestData = (RequestContext<TRequestEntity, TResponseEntity>) asynchronousResult.AsyncState;

            var request = requestData.Request;
            using (var requestStream = request.EndGetRequestStream(asynchronousResult))
            {
                using (var sw = new StreamWriter(requestStream))
                {
                    sw.Write(requestData.Body);
                }
            }

            request.BeginGetResponse(
                HandleResponseCallback<RequestContext<TRequestEntity, TResponseEntity>, TRequestEntity, TResponseEntity>,
                requestData);
        }
    }
}
