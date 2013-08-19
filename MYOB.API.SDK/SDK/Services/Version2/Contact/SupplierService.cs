using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Services.Contact
{
    public sealed class SupplierService : MutablePhotoService<Supplier>
    {
        public SupplierService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Contact/Supplier"; }
        }
    }
}