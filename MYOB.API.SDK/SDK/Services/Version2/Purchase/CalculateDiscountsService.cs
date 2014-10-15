using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;

namespace MYOB.AccountRight.SDK.Services.Purchase
{
    using System.Threading;

    /// <summary>
    /// A service that provides access to the <see cref="CalculateDiscounts"/> operation
    /// </summary>
    public sealed class CalculateDiscountsService : ServiceBase, IOperation<CalculateDiscounts, CalculateDiscountsResponse>
    {
        /// <summary>
        /// Initialise a service that can call the <see cref="CalculateDiscounts"/> operation
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public CalculateDiscountsService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Perform an operation and receive the response via an action
        /// </summary>
        /// <param name="cf">A reference to a company file</param>
        /// <param name="entity">The entity to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <returns>The operation response</returns>
        public CalculateDiscountsResponse Execute(CompanyFile cf, CalculateDiscounts entity, ICompanyFileCredentials credentials)
        {
            return MakeApiPostRequestSync<CalculateDiscounts, CalculateDiscountsResponse>(BuildUri(cf), entity, credentials).Value;
        }

        /// <summary>
        /// Perform an operation and wait for the response
        /// </summary>
        /// <param name="cf">A reference to a company file</param>
        /// <param name="entity">The entity to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void Execute(CompanyFile cf, CalculateDiscounts entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, CalculateDiscountsResponse> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiPostRequestDelegate(BuildUri(cf), entity, credentials, onComplete, onError);
        }

#if ASYNC
        /// <summary>
        /// Perform an asynchronous operation and await the response
        /// </summary>
        /// <param name="cf">A reference to a company file</param>
        /// <param name="entity">The entity to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <returns>The operation response</returns>
        public Task<CalculateDiscountsResponse> ExecuteAsync(CompanyFile cf, CalculateDiscounts entity, ICompanyFileCredentials credentials)
        {
            return this.ExecuteAsync(cf, entity, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Perform an asynchronous operation and await the response
        /// </summary>
        /// <param name="cf">A reference to a company file</param>
        /// <param name="entity">The entity to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The operation response</returns>
        public Task<CalculateDiscountsResponse> ExecuteAsync(CompanyFile cf, CalculateDiscounts entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiPostRequestAsync<CalculateDiscounts, CalculateDiscountsResponse>(this.BuildUri(cf), entity, credentials, cancellationToken);
        }
#endif

        private Uri BuildUri(CompanyFile companyFile, Guid? uid = null, string postResource = null)
        {
            return UriHelper.BuildUri(companyFile, Route, uid, postResource);
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public string Route
        {
            get
            {
                return "Purchase/SupplierPayment/CalculateDiscounts";
            }
        }
    }

}
