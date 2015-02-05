using System;
using System.Net;
#if ASYNC
using System.Threading;
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    /// <summary>
    /// AccountBudget Service interface
    /// </summary>
    public interface IAccountBudgetService
    {
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        void Get(CompanyFile cf, int financialYear, ICompanyFileCredentials credentials,
            Action<HttpStatusCode, AccountBudget> onComplete, Action<Uri, Exception> onError, string eTag = null);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        AccountBudget Get(CompanyFile cf, int financialYear, ICompanyFileCredentials credentials, string eTag = null);


#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, int financialYear, 
            ICompanyFileCredentials credentials, string eTag = null);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, int financialYear,
            ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null);
#endif

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials,
            Action<HttpStatusCode, AccountBudget> onComplete, Action<Uri, Exception> onError, string eTag = null);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        AccountBudget Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string eTag = null);

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string eTag = null);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials,
            CancellationToken cancellationToken, string eTag = null);
#endif

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        string Update(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
            ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

#if ASYNC
        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        Task<string> UpdateAsync(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
            ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> UpdateAsync(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
            CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
#endif

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="errorLevel"></param>
        void Update(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
            Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError,
            ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
    }
}