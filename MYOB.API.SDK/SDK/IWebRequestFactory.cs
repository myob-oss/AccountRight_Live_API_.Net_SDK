using System;
using System.Net;

namespace MYOB.AccountRight.SDK
{
    public interface IWebRequestFactory
    {
        /// <summary>
        /// Build a WebRequest object
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        WebRequest Create(Uri requestUri);
    }
}
