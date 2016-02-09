using System;
using System.IO;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif

#if PORTABLE
#endif

using System.IO.Compression;

namespace MYOB.AccountRight.SDK.Communication
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseRequestHandler
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IApiRequestHelper ApiRequestHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiRequestHelper"></param>
        protected BaseRequestHandler(IApiRequestHelper apiRequestHelper)
        {
            ApiRequestHelper = apiRequestHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        protected class RequestContext<TR>
        {
            /// <summary>
            /// The request
            /// </summary>
            public WebRequest Request { get; set; }

            /// <summary>
            /// The bod
            /// </summary>
            public string Body { get; set; }

            /// <summary>
            /// The action to perform when complete
            /// </summary>
            public Action<HttpStatusCode, string, TR> OnComplete { get; set; }

            /// <summary>
            /// The action to return on an error
            /// </summary>
            public Action<Uri, Exception> OnError { get; set; }
        }

#if ASYNC
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        protected Task<Tuple<HttpStatusCode, string, T>> GetResponseTask<T>(WebRequest request) where T : class
        {
            return GetResponseTask<T>(request, CancellationToken.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<Tuple<HttpStatusCode, string, T>> GetResponseTask<T>(WebRequest request, CancellationToken cancellationToken) where T : class
        {
            T entity = null;
            string location = null;
            var statusCode = HttpStatusCode.Unused;
            try
            {
                var response = await request.GetResponseAsync(cancellationToken);
                entity = ExtractDetails<T>(response, out location, out statusCode);                
            }
            catch (Exception wex)
            {
                wex.ProcessException(request.RequestUri);
            }
            return new Tuple<HttpStatusCode, string, T>(statusCode, location, entity);
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResp"></typeparam>
        /// <param name="asynchronousResult"></param>
        protected void HandleResponseCallback<T, TResp>(IAsyncResult asynchronousResult)
            where T : RequestContext<TResp>
            where TResp : class
        {
            var requestData = (T)asynchronousResult.AsyncState;
            var request = requestData.Request;
            var uri = request.RequestUri;

            try
            {
                var response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);

                string location;
                HttpStatusCode statusCode;
                var entity = ExtractDetails<TResp>(response, out location, out statusCode);

                requestData.OnComplete(response.StatusCode, location, entity);
            }
            catch (Exception ex)
            {
                requestData.OnError(uri, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string ExtractBody(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        private T ExtractDetails<T>(HttpWebResponse response, out string location, out HttpStatusCode statusCode)
            where T : class
        {
            location = response.Headers["Location"];
            statusCode = response.Maybe(_ => _.StatusCode);

            var entity = ApiRequestHelper.IsGZipped(response) ? ExtractJSonCompressedEntity<T>(response) : ExtractJSonEntity<T>(response);

            if (entity is IETagSupport)
                (entity as IETagSupport).ETag = (response.Headers["ETag"] ?? string.Empty); 

            return entity;
        }

        private static TResp ExtractJSonEntity<TResp>(WebResponse response)
        {
           return ExtractBody(response).FromJson<TResp>();
        }

        private static TResp ExtractJSonCompressedEntity<TResp>(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            using (var decompress = new GZipStream(responseStream, CompressionMode.Decompress))
            {
                using (var reader = new StreamReader(decompress))
                {
                    return reader.ReadToEnd().FromJson<TResp>();
                }
            }
        }
    }
}
