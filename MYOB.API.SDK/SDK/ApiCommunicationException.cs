using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;


namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// An exception that is thrown when there is a communication error i.e. web between the SDK and the account right servers
    /// </summary>
    [Serializable]
    public class ApiCommunicationException : Exception
    {
        protected ApiCommunicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = (HttpStatusCode)info.GetInt32("StatusCode");
            URI = (Uri)info.GetValue("URI", typeof(Uri));
            Errors = (IList<Error>)info.GetValue("Errors", typeof(IList<Error>));
            ErrorInformation = info.GetString("ErrorInformation");
            RequestId = info.GetString("RequestId");
        }

        /// <summary>
        /// A standard HTTP status
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// The URI of the service being accessed at the time
        /// </summary>
        public Uri URI { get; private set; }

        /// <summary>
        /// A list of errors extracted from the payload
        /// </summary>
        public IList<Error> Errors { get; private set; }

        /// <summary>
        /// Some extra error information
        /// </summary>
        public string ErrorInformation { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestId { get; private set; }

        /// <summary>
        /// Initializes an instance of the ApiCommunicationException class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="uri"></param>
        /// <param name="innerException"></param>
        /// <param name="listOfErrors"></param>
        /// <param name="information"></param>
        /// <param name="requestId"></param>
        public ApiCommunicationException(string message, HttpStatusCode statusCode, Uri uri, WebException innerException, IList<Error> listOfErrors, string information, string requestId)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            URI = uri;
            Errors = listOfErrors;
            ErrorInformation = information;
            RequestId = requestId;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("StatusCode", (int)StatusCode);
            info.AddValue("URI", URI);
            info.AddValue("Errors", Errors);
            info.AddValue("ErrorInformation", ErrorInformation);
            info.AddValue("RequestId", RequestId);
        }
    }

    /// <summary>
    /// An exception that is thrown when an error has occured within the API and is not communication related
    /// </summary>
    [Serializable]
    public class ApiOperationException : Exception
    {
        /// <summary>
        /// Initializes an instance of the ApiOperationException class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ApiOperationException(string message, Exception innerException) : base(message,innerException){}
    }

    /// <summary>
    /// An exception that is thrown when the API throws a validation exception
    /// </summary>
    [Serializable]
    public class ApiValidationException : ApiCommunicationException
    {
        /// <summary>
        /// Initializes an instance of the ApiCommunicationException class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="uri"></param>
        /// <param name="innerException"></param>
        /// <param name="listOfErrors"></param>
        /// <param name="information"></param>
        /// <param name="requestId"></param>
        public ApiValidationException(string message, HttpStatusCode statusCode, Uri uri, WebException innerException, IList<Error> listOfErrors, string information, string requestId)
            : base(message, statusCode, uri, innerException, listOfErrors, information, requestId)
        {
        }
    }
}
