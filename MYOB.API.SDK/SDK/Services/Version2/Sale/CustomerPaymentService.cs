using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Services.Sale
{
    using System.Threading;

    using MYOB.AccountRight.SDK.Contracts;

    /// <summary>
    /// A service that provides access to the <see cref="CustomerPayment"/> resource
    /// </summary>
    public sealed class CustomerPaymentService : MutableService<CustomerPayment>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="CustomerPayment"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public CustomerPaymentService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Sale/CustomerPayment"; }
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override string Update(Contracts.CompanyFile cf, CustomerPayment entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Update(Contracts.CompanyFile cf, CustomerPayment entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

#if ASYNC
        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> UpdateAsync(CompanyFile cf, CustomerPayment entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            return Task.Factory.StartNew<string>(() => { throw new NotSupportedException(); });       
        }
#endif
    }
}