using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Services.Sale
{
    public sealed class ProfessionalInvoiceService : MutableService<ProfessionalInvoice>
    {
        public ProfessionalInvoiceService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Sale/Invoice/Professional"; }
        }
    }
}