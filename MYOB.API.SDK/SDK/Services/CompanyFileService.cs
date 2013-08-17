using System;
using System.Net;
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
            MakeApiGetRequestAsync(new Uri(Configuration.ApiBaseUrl), null, onComplete, onError);
        }

        public void GetRange(string queryString, Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestAsync(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), null, onComplete, onError);
        }

        public CompanyFile[] GetRange()
        {
            return MakeApiGetRequestSync<CompanyFile[]>(new Uri(Configuration.ApiBaseUrl), null);
        } 
                
        public CompanyFile[] GetRange(string queryString)
        {
            return MakeApiGetRequestSync<CompanyFile[]>(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), null);
        }

        public void Get(CompanyFile cf, ICompanyFileCredentials credentials, Action<HttpStatusCode, CompanyFileWithResources> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestAsync(cf.Uri, credentials, onComplete, onError);
        }

        public CompanyFileWithResources Get(CompanyFile cf, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<CompanyFileWithResources>(cf.Uri, credentials);
        }

        private Uri BuildUri(string postResource = null)
        {
            return new Uri(string.Format("{0}/{1}", Configuration.ApiBaseUrl, postResource ?? string.Empty));
        }
    }
}
