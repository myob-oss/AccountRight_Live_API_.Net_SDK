using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// A base class that provides the support required for a service that supports GET operations for its resource
    /// </summary>
    /// <typeparam name="T">The resource type</typeparam>
    public abstract class ReadableService<T> : ReadableRangeService<T>, IReadable<T> where T : class
    {
        /// <summary>
        /// Initialise base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        protected ReadableService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string etag = null)
        {
            MakeApiGetRequestDelegate(BuildUri(cf, uid), credentials, onComplete, onError, etag);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual T Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, string etag = null)
        {
            return MakeApiGetRequestSync<T>(BuildUri(cf, uid), credentials, null, etag);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual Task<T> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, string etag = null)
        {
            return this.GetAsync(cf, uid, credentials, CancellationToken.None, etag);
        } 

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<T> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string etag = null)
        {
            return this.MakeApiGetRequestAsync<T>(this.BuildUri(cf, uid), credentials, cancellationToken, etag);
        } 
#endif

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string etag = null)
        {
            MakeApiGetRequestDelegate(ValidateUri(cf, uri), credentials, onComplete, onError, etag);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual T Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string etag = null)
        {
            return MakeApiGetRequestSync<T>(ValidateUri(cf, uri), credentials, null, etag);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual Task<T> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string etag = null)
        {
            return this.GetAsync(cf, uri, credentials, CancellationToken.None, etag);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<T> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string etag = null)
        {
            return this.MakeApiGetRequestAsync<T>(this.ValidateUri(cf, uri), credentials, cancellationToken, etag);
        } 
#endif

#if ASYNC

#endif
    }
}