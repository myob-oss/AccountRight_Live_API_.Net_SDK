using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Services.Sale;

namespace MYOB.AccountRight.SDK.Services.Purchase
{
    /// <summary>
    /// A service that provides access to the <see cref="ServicePurchaseOrder"/> resource
    /// </summary>
    public sealed class ServicePurchaseOrderService : PdfServiceBase<Contracts.Version2.Purchase.ServicePurchaseOrder>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="ServicePurchaseOrder"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public ServicePurchaseOrderService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Purchase/Order/Service"; }
        }
    }
}
