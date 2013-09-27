using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    public sealed class VersionInfoService : ServiceBase
    {
        public VersionInfoService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public void Get(ICompanyFileCredentials credentials, Action<HttpStatusCode, VersionInfo> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(), credentials, onComplete, onError);
        }

        public VersionInfo Get(ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<VersionInfo>(BuildUri(), credentials);
        }

#if ASYNC
        public Task<VersionInfo> GetAsync(ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestAsync<VersionInfo>(BuildUri(), credentials);
        }
#endif

        private Uri BuildUri()
        {
            return new Uri(string.Format("{0}/info", Configuration.ApiBaseUrl));
        }
    }
}