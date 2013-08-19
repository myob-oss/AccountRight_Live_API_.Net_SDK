using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MYOB.AccountRight.SDK
{
    public class ApiCommunicationException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public Uri URI { get; private set; }

        public ApiCommunicationException(string message, HttpStatusCode statusCode, Uri uri, WebException innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            URI = uri;
        }
    }

    public class ApiOperationException : Exception
    {
        public ApiOperationException(string message, Exception innerException) : base(message,innerException){}
    }
}
