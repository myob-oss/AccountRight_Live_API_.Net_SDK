using System;
using System.IO;
using System.Net;
using MYOB.AccountRight.SDK.Extensions;

#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif

#if PORTABLE
#endif

#if COMPRESSION
using System.IO.Compression;
#else
using SharpCompress.Compressor;
using SharpCompress.Compressor.Deflate;
#endif

namespace MYOB.AccountRight.SDK.Communication
{
    internal abstract class BaseRequestHandler
    {
        protected readonly IApiRequestHelper ApiRequestHelper;

        protected BaseRequestHandler(IApiRequestHelper apiRequestHelper)
        {
            ApiRequestHelper = apiRequestHelper;
        }

        protected class RequestContext<T, TR>
        {
            public WebRequest Request { get; set; }
            public string Body { get; set; }
            public Action<HttpStatusCode, string, TR> OnComplete { get; set; }
            public Action<Uri, Exception> OnError { get; set; }
        }

#if ASYNC
        protected Task<Tuple<HttpStatusCode, string, T>> GetResponseTask<T>(WebRequest request) where T : class
        {
            return this.GetResponseTask<T>(request, CancellationToken.None);
        }

        protected async Task<Tuple<HttpStatusCode, string, T>> GetResponseTask<T>(WebRequest request, CancellationToken cancellationToken) where T : class
        {
            var response = await request.GetResponseAsync(cancellationToken);
            var location = response.Headers["Location"];
            var statusCode = (response as HttpWebResponse).Maybe(_ => _.StatusCode);
            if (ApiRequestHelper.IsGZipped((HttpWebResponse)response))
            {
                var entityCompressed = ExtractJSonCompressedEntity<T>(response);
                return new Tuple<HttpStatusCode, string, T>(statusCode, location, entityCompressed);
            }
            var entityNormal = ExtractJSonEntity<T>(response);
            return new Tuple<HttpStatusCode, string, T>(statusCode, location, entityNormal);
        }
#endif

        protected void HandleResponseCallback<T, TReq, TResp>(IAsyncResult asynchronousResult)
            where T : RequestContext<TReq, TResp>
            where TResp : class
        {
            var requestData = (T)asynchronousResult.AsyncState;
            var request = requestData.Request;
            var uri = request.RequestUri;

            try
            {
                var response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                var location = response.Headers["Location"];

                if (ApiRequestHelper.IsGZipped(response))
                {
                    var entity = ExtractJSonCompressedEntity<TResp>(response);
                    requestData.OnComplete(response.StatusCode, location, entity);
                }
                else
                {
                    var entity = ExtractJSonEntity<TResp>(response);
                    requestData.OnComplete(response.StatusCode, location, entity);
                }
            }
            catch (Exception ex)
            {
                requestData.OnError(uri, ex);
            }
        }

        private static string ExtractBody(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
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
