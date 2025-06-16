using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// Interface for custom API request handling
    /// </summary>
    public interface IApiRequestHandler
    {
        /// <summary>
        /// GET - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="eTag"></param>
        void Get<T>(WebRequest request, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string eTag) where T : class;

        /// <summary>
        /// DELETE - asynchronous - using actions as handlers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void Delete(WebRequest request, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// PUT - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void Put<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// PUT - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void Put<TRequest, TResponse>(WebRequest request, TRequest entity, Action<HttpStatusCode, string, TResponse> onComplete, Action<Uri, Exception> onError) where TResponse : class;

        /// <summary>
        /// POST - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void Post<T>(WebRequest request, T entity, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError) where T : class;

        /// <summary>
        /// POST - asynchronous - using actions as handlers
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void Post<TRequest, TResponse>(WebRequest request, TRequest entity, Action<HttpStatusCode, string, TResponse> onComplete, Action<Uri, Exception> onError) where TResponse : class;

#if ASYNC
        /// <summary>
        /// GET - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        Task<Tuple<HttpStatusCode, T>> GetAsync<T>(WebRequest request, string eTag) where T : class;

        /// <summary>
        /// GET - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        Task<Tuple<HttpStatusCode, T>> GetAsync<T>(WebRequest request, CancellationToken cancellationToken, string eTag) where T : class;

        /// <summary>
        /// DELETE - async - awaitable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task DeleteAsync(WebRequest request);

        /// <summary>
        /// DELETE - async - awaitable
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(WebRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// PUT - async - awaitable 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> PutAsync<T>(WebRequest request, T entity) where T : class;

        /// <summary>
        /// PUT - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PutAsync<T>(WebRequest request, T entity, CancellationToken cancellationToken) where T : class;

        /// <summary>
        /// PUT - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TResponseEntity> PutAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity) where TRequestEntity : class where TResponseEntity : class;

        /// <summary>
        /// PUT - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResponseEntity> PutAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity, CancellationToken cancellationToken) where TRequestEntity : class where TResponseEntity : class;

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> PostAsync<T>(WebRequest request, T entity) where T : class;

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PostAsync<T>(WebRequest request, T entity, CancellationToken cancellationToken) where T : class;

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TResponseEntity> PostAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity) where TRequestEntity : class where TResponseEntity : class;

        /// <summary>
        /// POST - async - awaitable
        /// </summary>
        /// <typeparam name="TRequestEntity"></typeparam>
        /// <typeparam name="TResponseEntity"></typeparam>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResponseEntity> PostAsync<TRequestEntity, TResponseEntity>(WebRequest request, TRequestEntity entity, CancellationToken cancellationToken) where TRequestEntity : class where TResponseEntity : class;

#endif
    }
}