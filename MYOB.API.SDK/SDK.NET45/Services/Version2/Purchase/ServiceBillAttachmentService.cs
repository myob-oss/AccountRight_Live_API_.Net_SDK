using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MYOB.AccountRight.SDK.Services.Version2.Purchase
{
    /// <summary>
    /// A service that provides access to the <see cref="BillAttachmentWrapper"/> resource
    /// </summary>
    public class ServiceBillAttachmentService : MutableService<BillAttachmentWrapper>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="BillAttachmentWrapper"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public ServiceBillAttachmentService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        { }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "/Purchase/Bill/Service/{uid}/Attachment"; }
        }

        #region Insert Operations

        /// <summary>
        /// Adds an Attachment to a Bill
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="billUid">Guid of the Bill we're adding an Attachment to</param>
        /// <param name="entity">The request Object</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public BillAttachmentWrapper InsertEx(CompanyFile cf, Guid billUid, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestSync<BillAttachmentWrapper, BillAttachmentWrapper>(BuildUri(cf, billUid, null, queryString), entity, credentials).Value;
        }

#if ASYNC
        /// <summary>
        /// Adds an Attachment to a Bill asynchronously
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="billUid">Guid of the Bill we're adding an Attachment to</param>
        /// <param name="entity">The request Object</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public Task<BillAttachmentWrapper> InsertExAsync(CompanyFile cf, BillAttachmentWrapper entity, Guid billUid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel, true);
            return MakeApiPostRequestAsync<BillAttachmentWrapper, BillAttachmentWrapper>(BuildUri(cf, billUid, null, queryString), entity, credentials);
        }

#endif
        #endregion

        #region Get Operations

        /// <summary>
        /// Gets an Spend Money Attachment object
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="billUid">UID of the Bill</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public BillAttachmentWrapper Get(CompanyFile cf, Guid billUid, Guid attachmentUid, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestSync<BillAttachmentWrapper>(BuildUri(cf, billUid, attachmentUid, null), credentials, null);
        }

        /// <summary>
        /// Gets a Spend Money Attachment object
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="billUid">UID of the Bill</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public Task<BillAttachmentWrapper> GetAsync(CompanyFile cf, Guid billUid, Guid attachmentUid, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestAsync<BillAttachmentWrapper>(BuildUri(cf, billUid, attachmentUid, null), credentials, CancellationToken.None, eTag);
        }

        #endregion

        #region Delete Operations

        /// <summary>
        /// Delete a Bill Attachment
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="billUid">UID of the Bill</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        public void Delete(CompanyFile cf, Guid billUid, Guid attachmentUid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            MakeApiDeleteRequestSync(BuildUri(cf, billUid, attachmentUid, queryString), credentials);
        }

#if ASYNC
        /// <summary>
        /// Delete a Spend Money Attachment asynchronously
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="billUid">UID of the Bill</param>
        /// <param name="attachmentUid">UID of the Attachment to Delete</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel">Treat warnings as errors</param>
        /// <returns></returns>
        public Task DeleteAsync(CompanyFile cf, Guid billUid, Guid attachmentUid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            var queryString = GenerateQueryString(errorLevel);
            return MakeApiDeleteRequestAsync(BuildUri(cf, billUid, attachmentUid, queryString), credentials, CancellationToken.None);
        }
#endif
        #endregion

        #region Update Overrides

        /// <summary>
        /// Update not supported for this resource
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Update(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override string Update(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override Task<string> UpdateAsync(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override Task<string> UpdateAsync(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override void UpdateEx(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, BillAttachmentWrapper> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override BillAttachmentWrapper UpdateEx(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override Task<BillAttachmentWrapper> UpdateExAsync(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        public override Task<BillAttachmentWrapper> UpdateExAsync(CompanyFile cf, BillAttachmentWrapper entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
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
        // baseUrl/Purchase/Bill/Service/billUid/Attachment/attachmentUid
        // baseUrl/Purchase/Bill/Service/billUid/Attachment
        public Uri BuildUri(CompanyFile companyFile, Guid billUid, Guid? attachmentUid = null, string queryString = null)
        {
            var qs = string.IsNullOrEmpty(queryString) ? string.Empty : queryString;
            var attchUid = attachmentUid.HasValue ? "/" + attachmentUid.ToString() : string.Empty;

            return new Uri(string.Format("{0}/{1}/{2}{3}{4}", companyFile.Uri, "Purchase/Bill/Service", billUid.ToString(), "/Attachment", attchUid, qs));
        }
    }
}
