using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// A service that is used to fetch the available company files
    /// </summary>
    public sealed class CompanyFileService : ServiceBase, ICompanyFileService
    {
        /// <summary>
        /// Initialise a service that can fetch company files
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public CompanyFileService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void GetRange(Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(new Uri(Configuration.ApiBaseUrl), null, onComplete, onError, null);
        }

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <returns></returns>
        public CompanyFile[] GetRange()
        {
            return MakeApiGetRequestSync<CompanyFile[]>(new Uri(Configuration.ApiBaseUrl), null, null);
        }

#if ASYNC
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <returns></returns>
        public Task<CompanyFile[]> GetRangeAsync()
        {
            return this.GetRangeAsync(CancellationToken.None);
        } 

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CompanyFile[]> GetRangeAsync(CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<CompanyFile[]>(new Uri(this.Configuration.ApiBaseUrl), null, cancellationToken, null);
        } 
#endif
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void GetRange(string queryString, Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart('?'))), null, onComplete, onError, null);
        }

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <returns></returns>
        public CompanyFile[] GetRange(string queryString)
        {
            return MakeApiGetRequestSync<CompanyFile[]>(BuildUri(queryString.Maybe(_ => "?" + _.TrimStart('?'))), null, null);
        }

#if ASYNC
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <returns></returns>
        public Task<CompanyFile[]> GetRangeAsync(string queryString)
        {
            return this.GetRangeAsync(queryString, CancellationToken.None);
        } 

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CompanyFile[]> GetRangeAsync(string queryString, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<CompanyFile[]>(this.BuildUri(queryString.Maybe(_ => "?" + _.TrimStart('?'))), null, cancellationToken, null);
        } 
#endif
        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void Get(CompanyFile cf, ICompanyFileCredentials credentials, Action<HttpStatusCode, CompanyFileWithResources> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(cf.Uri, credentials, onComplete, onError, null);
        }

        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public CompanyFileWithResources Get(CompanyFile cf, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<CompanyFileWithResources>(cf.Uri, credentials, null);
        }

        /// <summary>
        /// Get a company file resource entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public CompanyFileWithResources GetCompanyResource(CompanyFile cf, ICompanyFileCredentials credentials)
        {
            Uri cfResourceEndPoint = new Uri(cf.Uri + "/company");
            return MakeApiGetRequestSync<CompanyFileWithResources>(cfResourceEndPoint, credentials, null);
        }

#if ASYNC
        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<CompanyFileWithResources> GetAsync(CompanyFile cf, ICompanyFileCredentials credentials)
        {
            return this.GetAsync(cf, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CompanyFileWithResources> GetAsync(CompanyFile cf, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<CompanyFileWithResources>(cf.Uri, credentials, cancellationToken, null);
        } 
#endif

        private Uri BuildUri(string postResource = null)
        {
            return new Uri(string.Format("{0}/{1}", Configuration.ApiBaseUrl, postResource ?? string.Empty));
        }
    }
}
