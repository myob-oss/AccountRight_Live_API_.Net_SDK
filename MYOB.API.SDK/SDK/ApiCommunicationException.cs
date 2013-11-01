using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// An exception that is thrown when there is a communication error i.e. web between the SDK and the account right servers
    /// </summary>
    public class ApiCommunicationException : Exception
    {
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
        /// Initializes an instance of the ApiCommunicationException class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="uri"></param>
        /// <param name="innerException"></param>
        /// <param name="listOfErrors"></param>
        /// <param name="Information"></param>
        public ApiCommunicationException(string message, HttpStatusCode statusCode, Uri uri, WebException innerException, IList<Error> listOfErrors, string Information)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            URI = uri;
            Errors = listOfErrors;
            ErrorInformation = Information; 
        }
    }

    /// <summary>
    /// An excpetion that is thrown when an error has occured within the API and is not communication related
    /// </summary>
    public class ApiOperationException : Exception
    {
        /// <summary>
        /// Initializes an instance of the ApiOperationException class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ApiOperationException(string message, Exception innerException) : base(message,innerException){}
    }
}
