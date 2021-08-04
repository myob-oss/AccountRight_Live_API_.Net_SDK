using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MYOB.AccountRight.SDK.Extensions
{
    /// <summary>
    /// Common exceltion handling utilities
    /// </summary>
    public static class ExceptionExtensions
    {
        internal class ErrorList
        {
            public IList<Error> Errors { get; set; }
            public string Information { get; set; }
        }

        /// <summary>
        /// Process an exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="requestUri"></param>
        public static void ProcessException(this Exception ex, Uri requestUri)
        {
            if (ex == null)
                return;

            var webEx = ex as WebException;
            if (webEx != null)
            {
                var webExResponse = webEx.Response as HttpWebResponse;
                var statusCode = (webExResponse).Maybe(_ => _.StatusCode);
                var info = string.Empty;
                if (webExResponse != null)
                {
                    var requestId =
                        webExResponse.Headers.Maybe(
                            h => h["x-myobapi-requestid"].Maybe(_ => _.ToLowerInvariant(), string.Empty));

                    using (var responseStream = webExResponse.GetResponseStream())
                    {
                        using (var stream = new MemoryStream())
                        {
                            var contentEncoding = (webExResponse.Headers?["Content-Encoding"] ?? "").ToLower();
                            if (contentEncoding.Contains("gzip"))
                            {
                                using (var gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
                                {
                                    CopyTo(gzipStream, stream);
                                }
                            }
                            else if (contentEncoding.Contains("deflate"))
                            {
                                using (var deflateStream = new DeflateStream(responseStream, CompressionMode.Decompress))
                                {
                                    CopyTo(deflateStream, stream);
                                }
                            }
                            else
                            {
                                CopyTo(responseStream, stream);
                            }

                            stream.Seek(0, SeekOrigin.Begin);
                            using (var reader = new StreamReader(stream))
                            {
                                var output = reader.ReadToEnd();
                                try
                                {
                                    if (statusCode == HttpStatusCode.BadRequest)
                                    {
                                        var list = output.FromJson<ErrorList>();
                                        var errList = list.Errors;
                                        info = list.Information;
                                        throw new ApiValidationException(
                                            string.Format("Encountered a validation error ({0})", requestUri),
                                            statusCode, requestUri, webEx, errList, info, requestId);
                                    }
                                }
                                catch (ApiValidationException)
                                {
                                    throw;
                                }
                                catch (Exception)
                                {
                                    info = output;
                                }
                            }

                        }
                    }
                    throw new ApiCommunicationException(
                    string.Format("Encountered a communication error ({0})", requestUri),
                    statusCode, requestUri, webEx, null, info, requestId);
                }
                throw new ApiCommunicationException(
                    string.Format("Encountered a communication error ({0})", requestUri),
                    statusCode, requestUri, webEx, null, info, null);
            }
            throw new ApiOperationException(string.Format("Encountered an operation error ({0})", requestUri), ex);
        }

        private static void CopyTo(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024];
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
    }
}