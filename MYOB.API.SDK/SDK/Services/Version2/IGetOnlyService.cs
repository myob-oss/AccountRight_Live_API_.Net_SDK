using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts.Version2;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// An interface that describes a service that supports a single read-only entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetOnlyService<T>
    {
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        T Get(CompanyFile companyFile, ICompanyFileCredentials credentials, string eTag = null);

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile"></param>
        /// <param name="credentials"></param>
        /// <param name="queryParameters"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        T Get(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, string eTag = null);

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        void Get(CompanyFile companyFile, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string eTag = null);



        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        void Get(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string eTag = null);

#if ASYNC
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile companyFile, ICompanyFileCredentials credentials, string eTag = null);

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile companyFile, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null);

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, string eTag = null);

        /// <summary>
        /// Get a resource using query parameters
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="queryParameters">The query parameters</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile companyFile, string queryParameters, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null);
#endif
    }
}