using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// Base class for resources that support mutable operations such as POST, PUT and DELETE
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MutableService<T> : ReadableService<T>, IMutable<T> where T : BaseEntity
    {
        /// <summary>
        /// Initialise base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        protected MutableService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        public virtual void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            MakeApiDeleteRequestSync(BuildUri(cf, uid, queryString: queryString), credentials);
        }

#if ASYNC
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public virtual Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            return DeleteAsync(cf, uid, credentials, CancellationToken.None, errorLevel);
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            return MakeApiDeleteRequestAsync(BuildUri(cf, uid, queryString: queryString), credentials, cancellationToken);
        }
#endif
        
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            MakeApiDeleteRequestDelegate(BuildUri(cf, uid, queryString: queryString), credentials, onComplete, onError);
        }

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public virtual string Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            return MakeApiPutRequestSync(BuildUri(cf, entity.UID, queryString: queryString), entity, credentials);
        }

#if ASYNC
        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public virtual Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            return UpdateAsync(cf, entity, credentials, CancellationToken.None, errorLevel);
        }

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            return MakeApiPutRequestAsync(BuildUri(cf, entity.UID, queryString: queryString), entity, credentials, cancellationToken);
        }
#endif

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            MakeApiPutRequestDelegate(BuildUri(cf, entity.UID, queryString: queryString), entity, credentials, onComplete, onError);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public virtual string Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            return MakeApiPostRequestSync(BuildUri(cf, queryString: queryString), entity, credentials);
        }

#if ASYNC
        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public virtual Task<string> InsertAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            return InsertAsync(cf, entity, credentials, CancellationToken.None, errorLevel);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public virtual Task<string> InsertAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            return MakeApiPostRequestAsync(BuildUri(cf, queryString: queryString), entity, credentials, cancellationToken);
        }
#endif

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            MakeApiPostRequestDelegate(BuildUri(cf, queryString: queryString), entity, credentials, onComplete, onError);
        }

        /// <exclude/>
        private static string QueryStringFromErrorLevel(ErrorLevel errorLevel)
        {
            return errorLevel == ErrorLevel.WarningsAsErrors ? "warningsAsErrors=true" : string.Empty;
        }
    }
}