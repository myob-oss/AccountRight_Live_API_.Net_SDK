using System;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using System.Collections.Generic;
using System.Threading;
using MYOB.AccountRight.SDK.Contracts.Version2;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts.Version2.Banking;

namespace MYOB.AccountRight.SDK.Services.Banking
{
    /// <summary>
    /// A service that provides access to the <see cref="SpendMoneyAttachmentWrapper"/> resource
    /// </summary>
    public class SpendMoneyAttachmentService : MutableService<SpendMoneyAttachmentWrapper>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="SpendMoneyAttachmentWrapper"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public SpendMoneyAttachmentService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        { }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Banking/SpendMoney/{uid}/Attachment"; }
        }

        #region Insert Operations

        /// <summary>
        /// Adds an Attachment to a Spend Money
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="spendMoneyUid">Guid of the Spend Money we're adding an Attachment to</param>
        /// <param name="entity">The request Object</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public SpendMoneyAttachmentWrapper InsertEx(CompanyFile cf, Guid spendMoneyUid, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestSync<SpendMoneyAttachmentWrapper, SpendMoneyAttachmentWrapper>(BuildUri(cf, spendMoneyUid, queryString), entity, credentials).Value;
        }

#if ASYNC
        /// <summary>
        /// Adds an Attachment to a Spend Money asynchronously
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="spendMoneyUid">Guid of the Spend Money we're adding an Attachment to</param>
        /// <param name="entity">The request Object</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public Task<SpendMoneyAttachmentWrapper> InsertExAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, Guid spendMoneyUid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestAsync<SpendMoneyAttachmentWrapper, SpendMoneyAttachmentWrapper>(BuildUri(cf, spendMoneyUid, null, queryString), entity, credentials);
        }


#endif
        #endregion

        #region Delete Operations


        /// <summary>
        /// Delete a Spend Money Attachment
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="spendMoneyUid">UID of the Spend Money</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        public void Delete(CompanyFile cf, Guid spendMoneyUid, Guid attachmentUid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            MakeApiDeleteRequestSync(BuildUri(cf, spendMoneyUid, attachmentUid, queryString), credentials);
        }

#if ASYNC
        /// <summary>
        /// Delete a Spend Money Attachment asynchronously
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="spendMoneyUid">UID of the Spend Money</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public Task DeleteAsync(CompanyFile cf, Guid spendMoneyUid, Guid attachmentUid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            return MakeApiDeleteRequestAsync(BuildUri(cf, spendMoneyUid, attachmentUid, queryString), credentials, CancellationToken.None);
        }
#endif

        #endregion

        #region Get Operations

        /// <summary>
        /// Gets an Spend Money Attachment object
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="spendMoneyUid">UID of the Spend Money</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public SpendMoneyAttachmentWrapper Get(CompanyFile cf, Guid spendMoneyUid, Guid attachmentUid, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestSync<SpendMoneyAttachmentWrapper>(BuildUri(cf, spendMoneyUid, attachmentUid, null), credentials, null);
        }

        /// <summary>
        /// Gets a Spend Money Attachment object
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="spendMoneyUid">UID of the Spend Money</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public Task<SpendMoneyAttachmentWrapper> GetAsync(CompanyFile cf, Guid spendMoneyUid, Guid attachmentUid, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestAsync<SpendMoneyAttachmentWrapper>(BuildUri(cf, spendMoneyUid, attachmentUid), credentials, CancellationToken.None, eTag);
        }

        #endregion

        #region Base Class Overrides

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        public override void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="eTag"></param>
        public override void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, SpendMoneyAttachmentWrapper> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override SpendMoneyAttachmentWrapper Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uri"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="eTag"></param>
        public override void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, SpendMoneyAttachmentWrapper> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uri"></param>
        /// <param name="credentials"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override SpendMoneyAttachmentWrapper Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uri"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uri"></param>
        /// <param name="credentials"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="queryString"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="eTag"></param>
        public override void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, Action<HttpStatusCode, PagedCollection<SpendMoneyAttachmentWrapper>> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="queryString"></param>
        /// <param name="credentials"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override PagedCollection<SpendMoneyAttachmentWrapper> GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="queryString"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override Task<PagedCollection<SpendMoneyAttachmentWrapper>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="queryString"></param>
        /// <param name="credentials"></param>
        /// <param name="eTag"></param>
        /// <returns></returns>
        public override Task<PagedCollection<SpendMoneyAttachmentWrapper>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Insert(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override string Insert(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> InsertAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> InsertAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void InsertEx(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, SpendMoneyAttachmentWrapper> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override SpendMoneyAttachmentWrapper InsertEx(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> InsertExAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT USE THIS INHERITED MEMBER
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> InsertExAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Update(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override string Update(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> UpdateAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> UpdateAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void UpdateEx(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, SpendMoneyAttachmentWrapper> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override SpendMoneyAttachmentWrapper UpdateEx(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> UpdateExAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<SpendMoneyAttachmentWrapper> UpdateExAsync(CompanyFile cf, SpendMoneyAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotImplementedException();
        }

        #endregion


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

        /// <exclude />
        // Examples:
        // baseUrl/Banking/SpendMoney/spendMoneyUid/Attachment/attachmentUid
        // baseUrl/Banking/SpendMoney/spendMoneyUid/Attachment
        public Uri BuildUri(CompanyFile companyFile, Guid spendMoneyUid, Guid? attachmentUid = null, string queryString = null)
        {
            var qs = string.IsNullOrEmpty(queryString) ? string.Empty : queryString;
            var attchUid = attachmentUid.HasValue ? "/" + attachmentUid.ToString() : string.Empty;

            return new Uri(string.Format("{0}/{1}/{2}{3}{4}{5}", companyFile.Uri, "Banking/SpendMoney", spendMoneyUid.ToString(), "/Attachment", attchUid, qs));
        }
    }
}
