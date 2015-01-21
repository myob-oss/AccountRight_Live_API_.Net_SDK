using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// An interface that describes a service that supports read operations i.e. GET Range
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadableRange<T> where T : class
    {
        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, Action<HttpStatusCode, PagedCollection<T>> onComplete, Action<Uri, Exception> onError, string etag = null);

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        PagedCollection<T> GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, string etag = null);

#if ASYNC
        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PagedCollection<T>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string etag = null);
#endif
    }

    /// <summary>
    /// An interface that describes a service that supports read operations i.e. GET
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadable<T> : IReadableRange<T> where T : class
    {
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string etag = null);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        T Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, string etag = null);

#if ASYNC

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string etag = null); 
#endif

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string etag = null);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        T Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string etag = null);

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string etag = null); 
#endif

#if ASYNC
#endif
    }
}