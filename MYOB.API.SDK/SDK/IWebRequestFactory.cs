using System;
using System.Net;

namespace MYOB.AccountRight.SDK
{
    public interface IWebRequestFactory
    {
        WebRequest Create(Uri requestUri);
    }
}
