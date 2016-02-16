using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts.Version2;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// A base class that only allows access to a resource that only supports a single read-only entity
    /// </summary>
    /// <typeparam name="T">The resource type</typeparam>
    public abstract class GetOnlyService<T> : ServiceBase, IGetOnlyService<T>
        where T : class
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
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public T Get(CompanyFile companyFile, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestSync<T>(BuildUri(companyFile), credentials, eTag);
        }

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public T Get(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestSync<T>(BuildUri(companyFile, queryParameters), credentials, eTag);
        }


        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        public void Get(CompanyFile companyFile, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            MakeApiGetRequestDelegate(BuildUri(companyFile), credentials, onComplete, onError, eTag);
        }

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        public void Get(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            MakeApiGetRequestDelegate(BuildUri(companyFile, queryParameters), credentials, onComplete, onError, eTag);
        }

#if ASYNC
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public Task<T> GetAsync(CompanyFile companyFile, ICompanyFileCredentials credentials, string eTag = null)
        {
            return this.GetAsync(companyFile, credentials, CancellationToken.None, eTag);
        }

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public Task<T> GetAsync(CompanyFile companyFile, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            return MakeApiGetRequestAsync<T>(BuildUri(companyFile), credentials, cancellationToken, eTag);
        }

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public Task<T> GetAsync(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, string eTag = null)
        {
            return GetAsync(companyFile, queryParameters, credentials, CancellationToken.None, eTag);
        }

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public Task<T> GetAsync(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            return MakeApiGetRequestAsync<T>(BuildUri(companyFile, queryParameters), credentials, cancellationToken, eTag);
        }

#endif

        /// <exclude/>
        protected Uri BuildUri(CompanyFile companyFile, string queryString = null)
        {
            return UriHelper.BuildUri(companyFile, Route, queryString: queryString);
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public abstract string Route { get; }
    }
}
