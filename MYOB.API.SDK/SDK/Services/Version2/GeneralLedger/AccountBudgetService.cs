using System;
using System.Net;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
#if ASYNC
using System.Threading;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Extensions;

#endif

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    /// <summary>
    /// Timesheet Service interface
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
        void Get(CompanyFile cf, int financialYear, ICompanyFileCredentials credentials,
                 Action<HttpStatusCode, AccountBudget> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        AccountBudget Get(CompanyFile cf, int financialYear, ICompanyFileCredentials credentials);


#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, int financialYear,
                                 ICompanyFileCredentials credentials);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, int financialYear,
                                 ICompanyFileCredentials credentials, CancellationToken cancellationToken);
#endif

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials,
                 Action<HttpStatusCode, AccountBudget> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        AccountBudget Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials);

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AccountBudget> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials,
                                 CancellationToken cancellationToken);
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

    /// <summary>
    /// A service that provides access to the <see cref="AccountBudget"/> resource
    /// </summary>
    public sealed class AccountBudgetService : ServiceBase, IAccountBudgetService
    {
        /// <summary>
        /// Initialise a service that can use <see cref="AccountBudget"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public AccountBudgetService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null,
                                IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void Get(CompanyFile cf, int financialYear,
                        ICompanyFileCredentials credentials, Action<HttpStatusCode, AccountBudget> onComplete,
                        Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(cf, financialYear), credentials, onComplete,
                                      onError);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public AccountBudget Get(CompanyFile cf, int financialYear,
                             ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<AccountBudget>(BuildUri(cf, financialYear),
                                                    credentials);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<AccountBudget> GetAsync(CompanyFile cf, int financialYear, ICompanyFileCredentials credentials)
        {
            return this.GetAsync(cf, financialYear, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="financialYear">The requested financial year</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountBudget> GetAsync(CompanyFile cf, int financialYear,
                                        ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<AccountBudget>(
                this.BuildUri(cf, financialYear), credentials, cancellationToken);
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
        public void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials,
                        Action<HttpStatusCode, AccountBudget> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(ValidateUri(cf, uri), credentials, onComplete, onError);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public AccountBudget Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<AccountBudget>(ValidateUri(cf, uri), credentials);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<AccountBudget> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
        {
            return this.GetAsync(cf, uri, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountBudget> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials,
                                        CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<AccountBudget>(ValidateUri(cf, uri), credentials, cancellationToken);
        }
#endif

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials,
                             Action<HttpStatusCode, PagedCollection<AccountBudget>> onComplete,
                             Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(
                BuildUri(cf, null, queryString == null ? null : "?" + queryString.TrimStart(new[] {'?'})), credentials,
                onComplete, onError);
        }

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public PagedCollection<AccountBudget> GetRange(CompanyFile cf, string queryString,
                                                   ICompanyFileCredentials credentials)
        {
            return
                MakeApiGetRequestSync<PagedCollection<AccountBudget>>(
                    BuildUri(cf, null, queryString == null ? null : "?" + queryString.TrimStart(new[] {'?'})),
                    credentials);
        }

#if ASYNC
        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<PagedCollection<AccountBudget>> GetRangeAsync(CompanyFile cf, string queryString,
                                                              ICompanyFileCredentials credentials)
        {
            return this.GetRangeAsync(cf, queryString, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<PagedCollection<AccountBudget>> GetRangeAsync(CompanyFile cf, string queryString,
                                                              ICompanyFileCredentials credentials,
                                                              CancellationToken cancellationToken)
        {
            return
                this.MakeApiGetRequestAsync<PagedCollection<AccountBudget>>(
                    this.BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart(new[] {'?'}))), credentials,
                    cancellationToken);
        }
#endif

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public string Update(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
                             ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            return
                MakeApiPutRequestSync(
                    BuildUri(cf, entity.FinancialYear,
                             extraQueryString: queryString), entity, credentials);
        }

#if ASYNC
        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public Task<string> UpdateAsync(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
                                        ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            return this.UpdateAsync(cf, entity, credentials, CancellationToken.None, errorLevel);
        }

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> UpdateAsync(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
                                        CancellationToken cancellationToken,
                                        ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            return
                this.MakeApiPutRequestAsync(
                    this.BuildUri(cf, entity.FinancialYear,
                                  extraQueryString: queryString), entity, credentials, cancellationToken);
        }
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
        public void Update(CompanyFile cf, AccountBudget entity, ICompanyFileCredentials credentials,
                           Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError,
                           ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            MakeApiPutRequestDelegate(
                BuildUri(cf, entity.FinancialYear, extraQueryString: queryString),
                entity, credentials, onComplete, onError);
        }

        private Uri BuildUri(CompanyFile companyFile, int? financialYear, string postResource = null, string extraQueryString = null)
        {
            string qs = null;
            if (!string.IsNullOrEmpty(extraQueryString)) qs += extraQueryString.TrimStart('?');

            var uri = UriHelper.BuildUri(companyFile, financialYear.HasValue ? string.Format("{0}/{1}", Route, financialYear) : Route, null, postResource, qs == null ? null : qs.TrimEnd('&'));
            return uri;
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public string Route
        {
            get { return "GeneralLedger/AccountBudget"; }
        }

        /// <exclude/>
        private static Uri ValidateUri(CompanyFile cf, Uri uri)
        {
            if (!uri.AbsoluteUri.ToLowerInvariant().StartsWith(cf.Uri.AbsoluteUri.ToLowerInvariant()))
                throw new ArgumentException("The supplied Uri is not valid for the company file.", "uri");
            return uri;
        }

        /// <exclude/>
        private static string QueryStringFromErrorLevel(ErrorLevel errorLevel)
        {
            return errorLevel == ErrorLevel.WarningsAsErrors ? "warningsAsErrors=true" : string.Empty;
        }
    }

}
