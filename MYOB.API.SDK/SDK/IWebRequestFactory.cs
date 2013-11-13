using System;
using System.Net;

namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// The interface for a factory classes that produces <see cref="WebRequest"/> objects.
    /// </summary>
    /// <remarks>
    /// Allows mocking during unit testing.
    /// Custom implementations should instead use <see cref="MYOB.AccountRight.SDK.Communication.WebRequestFactory"/>
    /// </remarks>
    /// <code>
    /// public class ProxyWebRequestFactory : WebRequestFactory // implements IWebRequestFactory
    /// {
    ///   public override WebRequest Create(Uri requestUri, string acceptEncoding = null)
    ///   {
    ///     var request = base.Create(requestUri, acceptEncoding);
    ///     request.Proxy = new WebProxy("http://alternateproxy:80/");
    ///     return request;
    ///   }
    /// }
    /// </code>
    public interface IWebRequestFactory
    {
        /// <summary>
        /// Build a WebRequest object
        /// </summary>
        /// <param name="requestUri">The uri</param>
        /// <param name="acceptEncoding">which specifies the MIME types that are acceptable for the response.</param>
        /// <returns></returns>
        WebRequest Create(Uri requestUri, string acceptEncoding = null);
    }
}
