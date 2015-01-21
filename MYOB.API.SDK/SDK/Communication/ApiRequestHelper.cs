using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

#if ASYNC
using System.Threading.Tasks;
#endif

#if PORTABLE
#endif

#if COMPRESSION
using System.IO.Compression;
#else
using SharpCompress.Compressor;
using SharpCompress.Compressor.Deflate;
#endif

namespace MYOB.AccountRight.SDK.Communication
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApiRequestHelper
    {
        /// <summary>
        /// Set common headers on the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="configuration"></param>
        /// <param name="credentials"></param>
        /// <param name="oauth"></param>
        void SetStandardHeaders(WebRequest request, IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null);

        /// <summary>
        /// Set Is-None-Match to request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="tag"></param>
        void SetIsNoneMatch(WebRequest request, string tag);

        /// <summary>
        /// Is the response compressed
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        bool IsGZipped(WebResponse response);

        /// <summary>
        /// Extract the compressed entity
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        Stream ExtractCompressedEntity(WebResponse response);
    }

    /// <summary>
    /// An ApiRequestHelper provide common utility methods
    /// </summary>
    public class ApiRequestHelper : IApiRequestHelper
    {
        /// <summary>
        /// Get the assembly version
        /// </summary>
        public static Version Version { get; private set; }

        /// <summary>
        /// Get the user agent string being applied
        /// </summary>
        public static string UserAgent { get; private set; }

        static ApiRequestHelper()
        {
            var name = typeof(ApiRequestHelper).Assembly.FullName;
            var asmName = new AssemblyName(name);
            Version = asmName.Version;
            UserAgent = string.Format("MYOB-ARL-SDK/{0} (+http://developer.myob.com/api/accountright/v2/)", Version.ToString(3));
        }

        /// <summary>
        /// Set common headers on the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="configuration"></param>
        /// <param name="credentials"></param>
        /// <param name="oauth"></param>
        public void SetStandardHeaders(WebRequest request, IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null)
        {
            request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", oauth.Maybe(_ => _.AccessToken, string.Empty));
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            
            IgnoreError(() =>
                {
#if PORTABLE
                    request.Headers[HttpRequestHeader.UserAgent] = UserAgent;
#else
                    try
                    {
                        var webRequest = request as HttpWebRequest;
                        if (webRequest != null)
                            webRequest.UserAgent = UserAgent;
                    }
                    catch (Exception)
                    {
                        request.Headers[HttpRequestHeader.UserAgent] = UserAgent;
                    }
#endif
                });

            request.Headers["x-myobapi-key"] = configuration.ClientId;
            request.Headers["x-myobapi-version"] = "v2";
            request.Headers["x-myobapi-cftoken"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", 
                credentials.Maybe(_ => _.Username).Maybe(_ => _, string.Empty), credentials.Maybe(_ => _.Password).Maybe(_ => _, string.Empty))));
        }

        /// <summary>
        /// Set Is-None-Match to request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="tag"></param>
        public void SetIsNoneMatch(WebRequest request, string tag)
        {
            request.Headers[HttpRequestHeader.IfNoneMatch] = tag;
        }

        /// <summary>
        /// Is the response compressed
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool IsGZipped(WebResponse response)
        {
            return response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].Contains("gzip");
        }

        /// <summary>
        /// Extract the compressed entity
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public Stream ExtractCompressedEntity(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            return new GZipStream(responseStream, CompressionMode.Decompress);         
        }

        /// <summary>
        /// swallow errors
        /// </summary>
        /// <param name="a"></param>
        public static void IgnoreError(Action a)
        {
            try
            {
                a();
            }
            catch(Exception){}
        }
    }
}
