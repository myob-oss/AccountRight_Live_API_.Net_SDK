using System;
using System.Net;

namespace MYOB.AccountRight.SDK.Extensions
{
    internal static class ExceptionExtensions
    {
        public static void ProcessException(this Exception ex, Uri requestUri)
        {
            if (ex == null) return;

            var webEx = ex as WebException;
            if (webEx != null)
            {
                var statusCode = (webEx.Response as HttpWebResponse).Maybe(_ => _.StatusCode);
                throw new ApiCommunicationException(string.Format("Encountered a communication error ({0})", requestUri),
                                                    statusCode, requestUri, webEx);
            }
            throw new ApiOperationException(string.Format("Encountered an operation error ({0})", requestUri), ex);
        }
    }
}