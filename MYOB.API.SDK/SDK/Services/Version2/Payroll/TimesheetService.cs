using System;
using System.Net;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Payroll;
#if ASYNC
using System.Threading;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling;
using MYOB.AccountRight.SDK.Extensions;

#endif

namespace MYOB.AccountRight.SDK.Services.Payroll
{
    /// <summary>
    /// Timesheet Service interface
    /// </summary>
    public interface ITimesheetService
    {
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials, Action<HttpStatusCode, Timesheet> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Timesheet Get(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials);


#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<Timesheet> GetAsync(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Timesheet> GetAsync(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials, CancellationToken cancellationToken);
#endif

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, Timesheet> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Timesheet Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials);

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<Timesheet> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials);

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Timesheet> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken);
#endif

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        string Update(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
#if ASYNC
        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        Task<string> UpdateAsync(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> UpdateAsync(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
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
        void Update(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings);
    }

    /// <summary>
    /// A service that provides access to the <see cref="Timesheet"/> resource
    /// </summary>
    public sealed class TimesheetService : ServiceBase, ITimesheetService
    {
        /// <summary>
        /// Initialise a service that can use <see cref="Timesheet"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public TimesheetService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void Get(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials, Action<HttpStatusCode, Timesheet> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(cf, uid, startDate: startDate, endDate: endDate), credentials, onComplete, onError, null);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Timesheet Get(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<Timesheet>(BuildUri(cf, uid, startDate: startDate, endDate: endDate), credentials, null);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<Timesheet> GetAsync(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials)
        {
            return this.GetAsync(cf, uid, startDate, endDate, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="startDate">Timesheet start date</param>
        /// <param name="endDate">Timesheet end date</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Timesheet> GetAsync(CompanyFile cf, Guid uid, DateTime? startDate, DateTime? endDate, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<Timesheet>(this.BuildUri(cf, uid, startDate: startDate, endDate: endDate), credentials, cancellationToken, null);
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
        public void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, Timesheet> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(ValidateUri(cf, uri), credentials, onComplete, onError, null);
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Timesheet Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<Timesheet>(ValidateUri(cf, uri), credentials, null);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<Timesheet> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
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
        public Task<Timesheet> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<Timesheet>(ValidateUri(cf, uri), credentials, cancellationToken, null);
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
        public void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, Action<HttpStatusCode, PagedCollection<Timesheet>> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(cf, postResource: queryString == null ? null : "?" + queryString.TrimStart('?')), credentials, onComplete, onError, null);
        }

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public PagedCollection<Timesheet> GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<PagedCollection<Timesheet>>(BuildUri(cf, postResource: queryString == null ? null : "?" + queryString.TrimStart('?')), credentials, null);
        }

#if ASYNC
        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<PagedCollection<Timesheet>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials)
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
        public Task<PagedCollection<Timesheet>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<PagedCollection<Timesheet>>(this.BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart('?'))), credentials, cancellationToken, null);
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
        public string Update(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            return MakeApiPutRequestSync(BuildUri(cf, entity.Employee == null ? (Guid?)null : entity.Employee.UID, extraQueryString:queryString), entity, credentials);
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
        public Task<string> UpdateAsync(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public Task<string> UpdateAsync(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);

            return this.MakeApiPutRequestAsync(this.BuildUri(cf, entity.Employee == null ? (Guid?)null : entity.Employee.UID, extraQueryString: queryString), entity, credentials, cancellationToken);
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
        public void Update(CompanyFile cf, Timesheet entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = QueryStringFromErrorLevel(errorLevel);
            MakeApiPutRequestDelegate(BuildUri(cf, entity.Employee == null ? (Guid?)null : entity.Employee.UID, extraQueryString: queryString), entity, credentials, onComplete, onError);
        }

        private Uri BuildUri(CompanyFile companyFile, Guid? uid = null, string postResource = null, DateTime? startDate = null, DateTime? endDate = null, string extraQueryString = null)
        {
            string qs = null;
            if (startDate.HasValue) 
                qs+= string.Format("StartDate={0}&", startDate.Value.Date.ToString("s"));
            if (endDate.HasValue) 
                qs += string.Format("EndDate={0}&", endDate.Value.Date.ToString("s"));
            if (!string.IsNullOrEmpty(extraQueryString)) 
                qs += extraQueryString.TrimStart('?');

            return UriHelper.BuildUri(companyFile, Route, uid, postResource, qs == null ? null : qs.TrimEnd('&'));
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public string Route
        {
            get
            {
                return "Payroll/Timesheet";
            }
        }

        /// <exclude/>
        static Uri ValidateUri(CompanyFile cf, Uri uri)
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