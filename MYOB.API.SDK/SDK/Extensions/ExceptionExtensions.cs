using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MYOB.AccountRight.SDK.Extensions
{
    
    internal static class ExceptionExtensions
    {
        internal class ErrorList
        {
            public IList<Error> Errors { get; set; }
            public string Information { get; set; }
        }

        public static void ProcessException(this Exception ex, Uri requestUri)
        {
            if (ex == null) return;

            var webEx = ex as WebException;
            if (webEx != null)
            {
                var statusCode = (webEx.Response as HttpWebResponse).Maybe(_ => _.StatusCode);
                IList<Error> errList = null;
                string info = string.Empty;
                if (webEx.Response != null)
                {
                    using (var stream = webEx.Response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var output = reader.ReadToEnd();
                            try
                            {
                                var list = output.FromJson<ErrorList>();
                                errList = list.Errors;
                                info = list.Information;
                            }
                            catch (JsonReaderException) //If output is invalid number string without quote, then it would assume is number and return this exception.
                            {
                                info = output;
                            }
                            catch (JsonSerializationException)
                            {
                                info = output; 
                            }
                        }
                    }
                }
                throw new ApiCommunicationException(string.Format("Encountered a communication error ({0})", requestUri),
                                                    statusCode, requestUri, webEx, errList, info);
            }
            throw new ApiOperationException(string.Format("Encountered an operation error ({0})", requestUri), ex);
        }
    }
}