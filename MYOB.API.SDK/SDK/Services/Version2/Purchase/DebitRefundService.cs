using System;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;

namespace MYOB.AccountRight.SDK.Services.Purchase
{
    /// <summary>
    /// A service that provides access to the <see cref="DebitRefund"/> resource
    /// </summary>
    public sealed class DebitRefundService : MutableService<DebitRefund>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="DebitRefund"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public DebitRefundService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Purchase/DebitRefund"; }
        }

        /// <summary>
        /// The Update method is not supported
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override string Update(Contracts.CompanyFile cf, DebitRefund entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// The Update method is not supported
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="errorLevel"></param>
        public override void Update(Contracts.CompanyFile cf, DebitRefund entity, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

#if ASYNC
        /// <summary>
        /// The Update method is not supported
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="entity">The entity to update</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override System.Threading.Tasks.Task<string> UpdateAsync(Contracts.CompanyFile cf, DebitRefund entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }
#endif
    }
}