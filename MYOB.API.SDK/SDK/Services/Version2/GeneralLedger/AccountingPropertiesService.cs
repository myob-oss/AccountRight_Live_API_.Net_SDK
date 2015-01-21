using System;
using System.Net;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Extensions;
#if ASYNC
using System.Threading;
using System.Threading.Tasks;
#endif

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    /// <summary>
    /// A service that provides access to the <see cref="AccountingProperties"/> resource
    /// </summary>
    public sealed class AccountingPropertiesService : ReadableService<AccountingProperties>
    {
        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "GeneralLedger/AccountingProperties"; }
        }

        /// <summary>
        /// Initialise a service that can use <see cref="AccountingProperties"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public AccountingPropertiesService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Retrieve an <see cref="AccountingProperties"/> resource
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public override AccountingProperties Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, string etag = null)
        {
            return base.GetRange(cf, null, credentials, etag).Items.Maybe(_ => _[0]);
        }

        /// <summary>
        /// Retrieve an <see cref="AccountingProperties"/> resource
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public override void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, AccountingProperties> onComplete, Action<Uri, Exception> onError, string etag = null)
        {
            base.GetRange(cf, null, credentials, (code, collection) => onComplete(code, collection.Items.Maybe(_ => _[0])), onError, etag);
        }

#if ASYNC
        /// <summary>
        /// Retrieve an <see cref="AccountingProperties"/> resource
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task<AccountingProperties> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string etag = null)
        {
            var res = await base.GetRangeAsync(cf, null, credentials, cancellationToken, etag);
            return res.Items[0];
        }  
#endif   
 
    }
}
