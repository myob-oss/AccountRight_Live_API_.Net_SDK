using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
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
    /// <summary>
    /// Handles API requests
    /// </summary>
    public class ApiRequestHandler : BaseRequestHandler
    {
        /// <summary>
        /// The default production endpoint
        /// </summary>
        public static Uri ApiRequestUri = new Uri("https://api.myob.com/accountright");

        private readonly OAuthTokens _oauth;
        private readonly IApiConfiguration _configuration;
        private readonly ICompanyFileCredentials _credentials;

        /// <summary>
        /// Construct and ApiRequestHandler entity
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="credentials"></param>
        /// <param name="oauth"></param>
        public ApiRequestHandler(IApiConfiguration configuration, ICompanyFileCredentials credentials,
                                 OAuthTokens oauth = null)
            : base(new ApiRequestHelper())
        {
            _oauth = oauth;
            _configuration = configuration;
            _credentials = credentials;
        }

        /// <summary>
        /// GET - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        public void Get<T>(WebRequest request, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string etag = null)
            where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            ApiRequestHelper.SetIsNoneMatch(request, etag);

            request.BeginGetResponse(HandleResponseCallback<RequestContext<string, T>, string, T>,
                                     new RequestContext<string, T>
                                         {
                                             Request = request,
                                             OnComplete = (code, s, entity) => onComplete(code, entity),
                                             OnError = onError,
                                         });
        }

#if ASYNC
        /// <summary>
        /// GET - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Tuple<HttpStatusCode, T>> GetAsync<T>(WebRequest request) where T : class
        {
            return this.GetAsync<T>(request, CancellationToken.None);
        }

        /// <summary>
        /// GET - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Tuple<HttpStatusCode, T>> GetAsync<T>(WebRequest request, CancellationToken cancellationToken, string etag = null) where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            ApiRequestHelper.SetIsNoneMatch(request, etag);

            var get = await GetResponseTask<T>(request, cancellationToken);
            return new Tuple<HttpStatusCode, T>(get.Item1, get.Item3);
        }
#endif

        /// <summary>
        /// DELETE - asynchronous - using actions as handlers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
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
        /// <summary>
        /// DELETE - async - awaitable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task DeleteAsync(WebRequest request)
        {
            return this.DeleteAsync(request, CancellationToken.None);
        }

        /// <summary>
        /// DELETE - async - awaitable
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAsync(WebRequest request, CancellationToken cancellationToken)
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "DELETE";
            await GetResponseTask<string>(request, cancellationToken);
        }
#endif

        /// <summary>
        /// PUT - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        public void Put<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete,
                           Action<Uri, Exception> onError)
        {
            Put<T, string>(request, entity, (code, s, response) => onComplete(code, s), onError);
        }

        /// <summary>
        /// PUT - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        public void Put<TRequest, TResponse>(WebRequest request, TRequest entity, Action<HttpStatusCode, string, TResponse> onComplete,
                           Action<Uri, Exception> onError)
            where TResponse : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "PUT";
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
        /// <summary>
        /// PUT - async - awaitable 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<string> PutAsync<T>(WebRequest request, T entity) where T : class
        {
            return this.PutAsync(request, entity, CancellationToken.None);
        }

        /// <summary>
        /// PUT - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> PutAsync<T>(WebRequest request, T entity, CancellationToken cancellationToken) where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var res = await GetRequestStreamTask(request, entity);

            return (await GetResponseTask<T>(res, cancellationToken)).Item2;
        }

        /// <summary>
        /// PUT - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TResponseEntity> PutAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            return this.PutAsync<TRequestEntity, TResponseEntity>(request, entity, CancellationToken.None);
        }

        /// <summary>
        /// PUT - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponseEntity> PutAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity, CancellationToken cancellationToken)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "PUT";
            request.ContentType = "application/json";

            var res = await GetRequestStreamTask(request, entity);

            return (await GetResponseTask<TResponseEntity>(res, cancellationToken)).Item3;
        }
#endif

        /// <summary>
        /// POST - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        public void Post<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete,
                            Action<Uri, Exception> onError)
            where T : class
        {
            Post<T, string>(request, entity, (code, s, response) => onComplete(code, s), onError);
        }

        /// <summary>
        /// POST - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
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
        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<string> PostAsync<T>(WebRequest request, T entity) where T : class
        {
            return this.PostAsync(request, entity, CancellationToken.None);
        }

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> PostAsync<T>(WebRequest request, T entity, CancellationToken cancellationToken) where T : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "POST";
            request.ContentType = "application/json";
            var res = await GetRequestStreamTask(request, entity);

            return (await GetResponseTask<T>(res, cancellationToken)).Item2;
        }

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TResponseEntity> PostAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            return this.PostAsync<TRequestEntity, TResponseEntity>(request, entity, CancellationToken.None);
        }

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponseEntity> PostAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity, CancellationToken cancellationToken)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            ApiRequestHelper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
            request.Method = "POST";
            request.ContentType = "application/json";

            var res = await GetRequestStreamTask(request, entity);
            
            return (await GetResponseTask<TResponseEntity>(res, cancellationToken)).Item3;
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
