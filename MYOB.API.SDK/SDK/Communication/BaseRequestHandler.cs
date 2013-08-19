using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MYOB.AccountRight.SDK.Extensions;
using SharpCompress.Compressor;
using SharpCompress.Compressor.Deflate;

namespace MYOB.AccountRight.SDK.Communication
{
    internal abstract class BaseRequestHandler
    {
        protected class RequestContext<T, TR>
        {
            public WebRequest Request { get; set; }
            public string Body { get; set; }
            public Action<HttpStatusCode, string, TR> OnComplete { get; set; }
            public Action<Uri, Exception> OnError { get; set; }
        }

        protected static void HandleResponseCallback<T, TReq, TResp>(IAsyncResult asynchronousResult)
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

                if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].Contains("gzip"))
                {
                    var entity = ExtractCompressedEntity<TResp>(response);
                    requestData.OnComplete(response.StatusCode, location, entity);
                }
                else
                {
                    var entity = ExtractEntity<TResp>(response);
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

        private static TResp ExtractEntity<TResp>(WebResponse response)
        {
           return ExtractBody(response).FromJson<TResp>();
        }

        private static TResp ExtractCompressedEntity<TResp>(WebResponse response)
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
