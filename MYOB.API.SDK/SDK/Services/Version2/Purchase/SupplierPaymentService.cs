using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;

namespace MYOB.AccountRight.SDK.Services.Purchase
{
    public class SupplierPaymentService : MutableService<SupplierPayment>
    {
        public SupplierPaymentService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Purchase/SupplierPayment"; }
        }
    }
}