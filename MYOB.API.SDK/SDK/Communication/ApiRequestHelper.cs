using System;
using System.IO;
using System.Net;
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
    internal interface IApiRequestHelper
    {
        void SetStandardHeaders(WebRequest request, IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null);
        bool IsGZipped(WebResponse response);
        Stream ExtractCompressedEntity(WebResponse response);
    }

    internal class ApiRequestHelper : IApiRequestHelper
    {
        public void SetStandardHeaders(WebRequest request, IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null)
        {
            request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", oauth.Maybe(_ => _.AccessToken, string.Empty));
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            request.Headers["x-myobapi-key"] = configuration.ClientId;
            request.Headers["x-myobapi-version"] = "v2";
            request.Headers["x-myobapi-cftoken"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", 
                credentials.Maybe(_ => _.Username).Maybe(_ => _, string.Empty), credentials.Maybe(_ => _.Password).Maybe(_ => _, string.Empty))));
        }

        public bool IsGZipped(WebResponse response)
        {
            return response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].Contains("gzip");
        }

        public Stream ExtractCompressedEntity(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            return new GZipStream(responseStream, CompressionMode.Decompress);         
        }
    }
}
