using System;
using System.Net;

namespace MYOB.AccountRight.SDK.Communication
{
    public class WebRequestFactory : IWebRequestFactory
    {
        public WebRequest Create(Uri requestUri)
        {
            return WebRequest.Create(requestUri);
        }
    }
}