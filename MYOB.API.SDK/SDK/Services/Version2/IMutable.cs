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
    /// The interface describing services that support mutable resources
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMutable<T> : IReadable<T> where T : BaseEntity
    {
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

#if ASYNC

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
#endif

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="errorLevel"></param>
        void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        string Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

#if ASYNC
        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
#endif

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        void Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        string Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
        
#if ASYNC
        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        Task<string> InsertAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        Task<string> InsertAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

#endif

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        void Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

    }
}