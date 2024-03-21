using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MYOB.AccountRight.SDK.Services.Version2.Purchase
{
    /// <summary>
    /// A service that provides access to the <see cref="BillAttachmentsData"/> resource
    /// </summary>
    public class BillAttachmentsDataService : MutableService<BillAttachmentsData>
    {
        private string _layout;
        private Guid _uid;

        /// <summary>
        /// Initialise a service that can use <see cref="BillAttachmentsData"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public BillAttachmentsDataService(IApiConfiguration configuration, string Layout = null, string UID = null, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
            _layout = Layout;
            _uid = Guid.Parse(UID);
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return $"Purchase/Bill/{_layout}/{_uid}/Attachment"; }
        }

        #region Insert Overrides

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns><see cref="BillAttachmentsData"/></returns>
        public override BillAttachmentsData InsertEx(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestSync<BillAttachmentsData, BillAttachmentsData>(BuildUri(cf, entity, queryString: queryString), entity, credentials).Value;
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public override void Insert(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            MakeApiPostRequestDelegate(BuildUri(cf, entity, queryString), entity, credentials, onComplete, onError);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns>The location to the new entity</returns>
        public override string Insert(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestSync(BuildUri(cf, entity, queryString), entity, credentials);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public override void InsertEx(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, BillAttachmentsData> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            MakeApiPostRequestDelegate(BuildUri(cf, entity, queryString), entity, credentials, onComplete, onError);
        }

#if ASYNC
        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns>The location to the new entity</returns>
        public override Task<string> InsertAsync(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestAsync(BuildUri(cf, entity, queryString), entity, credentials, cancellationToken);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns>The location to the new entity</returns>
        public override Task<string> InsertAsync(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            return this.InsertAsync(cf, entity, credentials, CancellationToken.None, errorLevel);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns>The inserted entity</returns>
        public override Task<BillAttachmentsData> InsertExAsync(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestAsync<BillAttachmentsData, BillAttachmentsData>(BuildUri(cf, entity, queryString), entity, credentials, cancellationToken);
        }

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns>The inserted entity</returns>
        public override Task<BillAttachmentsData> InsertExAsync(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            return this.InsertExAsync(cf, entity, credentials, CancellationToken.None, errorLevel);
        }

#endif
        #endregion

        #region Delete method

        /// <summary>
        /// Delete an Attachment
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uri">Uri of the Thumbnail from the Get response</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        public void Delete(CompanyFile cf, string uri, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            var deleteUri = new Uri(string.Format("{0}{1}", uri, queryString));
            MakeApiDeleteRequestSync(deleteUri, credentials);
        }

        #endregion

        #region Update Not Supported Overrides

        /// <summary>
        /// Update (PUT) not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Update(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

#if ASYNC
        /// <summary>
        /// Update (PUT) not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> UpdateAsync(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Update (PUT) not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void UpdateEx(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, BillAttachmentsData> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

#if ASYNC
        /// <summary>
        /// Update (PUT) not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<BillAttachmentsData> UpdateExAsync(CompanyFile cf, BillAttachmentsData entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }
#endif
        #endregion

        // Route depends on Layout and UID which is not in the entity by default
        private Uri BuildUri(CompanyFile companyFile, BillAttachmentsData entity, string queryString = null)
        {
            // Building up nested routes to support multiple resource types
            var route = $"Purchase/Bill/{entity.BillLayout}/";
            return UriHelper.BuildUri(companyFile, route, entity.BillUID, "/Attachment", queryString);
        }

        /// <exclude/>
        private string GenerateQueryString(ErrorLevel errorLevel, bool returnBody = false)
        {
            var qs = new List<string>();
            if (errorLevel == ErrorLevel.WarningsAsErrors)
                qs.Add("warningsAsErrors=true");
            if (returnBody)
                qs.Add("returnBody=true");
            if (!Configuration.GenerateUris)
                qs.Add("generateUris=false");
            return string.Join("&", qs.ToArray());
        }
    }
}
