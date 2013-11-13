using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// A base class that only allows access to a resource that only supports a single read-only entity
    /// </summary>
    /// <typeparam name="T">The resource type</typeparam>
    public abstract class GetOnlyService<T> : ServiceBase, IGetOnlyService<T>
        where T: class
    {

        /// <summary>
        /// Initialise a base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        protected GetOnlyService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }
        
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <returns></returns>
        public T Get(CompanyFile companyFile, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<T>(BuildUri(companyFile), credentials);
        }

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void Get(CompanyFile companyFile, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(companyFile), credentials, onComplete, onError);
        }

#if ASYNC
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <returns></returns>
        public Task<T> GetAsync(CompanyFile companyFile, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestAsync<T>(BuildUri(companyFile), credentials);
        }
#endif
        /// <exclude/>
        protected Uri BuildUri(CompanyFile companyFile)
        {
            return UriHelper.BuildUri(companyFile, Route);
        }

        internal abstract string Route { get; }
    }
}
