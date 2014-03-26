using System;
using System.Net;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Communication
{
    /// <summary>
    /// A factory that produces <see cref="WebRequest"/> objects
    /// </summary>
    /// <remarks>
    /// Custom implementations of <see cref="IWebRequestFactory"/> should extend this class.
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
    public class WebRequestFactory : IWebRequestFactory
    {
        private IApiConfiguration _configuration;

        /// <summary>
        /// WebRequest factory constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public WebRequestFactory(IApiConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Build a WebRequest object
        /// </summary>
        /// <param name="requestUri">The uri</param>
        /// <param name="acceptEncoding">which specifies the MIME types that are acceptable for the response.</param>
        /// <returns>A <see cref="WebRequest"/> object with the supplied encoding set.</returns>
        public virtual WebRequest Create(Uri requestUri, string acceptEncoding = null)
        {
            var webrequest = (HttpWebRequest)WebRequest.Create(requestUri);
            webrequest.Accept = acceptEncoding;

#if !PORTABLE
            webrequest.CachePolicy = _configuration.RequestCachePolicy;
#endif

            return webrequest;
        }
    }
}