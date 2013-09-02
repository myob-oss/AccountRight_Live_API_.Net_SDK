using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services.GeneralLedger;

namespace MYOB.AccountRight.SDK.Services
{
    public sealed class CompanyFileService : ServiceBase, ICompanyFileService
    {
        public CompanyFileService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public void GetRange(Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(new Uri(Configuration.ApiBaseUrl), null, onComplete, onError);
        }

#if ASYNC
        public Task<CompanyFile[]> GetRangeAsync()
        {
            return MakeApiGetRequestAsync<CompanyFile[]>(new Uri(Configuration.ApiBaseUrl), null);
        } 
#endif

        public void GetRange(string queryString, Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), null, onComplete, onError);
        }

        public CompanyFile[] GetRange()
        {
            return MakeApiGetRequestSync<CompanyFile[]>(new Uri(Configuration.ApiBaseUrl), null);
        }
        
        public CompanyFile[] GetRange(string queryString)
        {
            return MakeApiGetRequestSync<CompanyFile[]>(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), null);
        }

#if ASYNC
        public Task<CompanyFile[]> GetRangeAsync(string queryString)
        {
            return MakeApiGetRequestAsync<CompanyFile[]>(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), null);
        } 
#endif

        public void Get(CompanyFile cf, ICompanyFileCredentials credentials, Action<HttpStatusCode, CompanyFileWithResources> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(cf.Uri, credentials, onComplete, onError);
        }

        public CompanyFileWithResources Get(CompanyFile cf, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<CompanyFileWithResources>(cf.Uri, credentials);
        }

#if ASYNC
        public Task<CompanyFileWithResources> GetAsync(CompanyFile cf, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestAsync<CompanyFileWithResources>(cf.Uri, credentials);
        } 
#endif

        private Uri BuildUri(string postResource = null)
        {
            return new Uri(string.Format("{0}/{1}", Configuration.ApiBaseUrl, postResource ?? string.Empty));
        }
    }
}
