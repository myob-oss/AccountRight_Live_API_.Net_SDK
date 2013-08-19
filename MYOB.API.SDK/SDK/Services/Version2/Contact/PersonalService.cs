using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Services.Contact
{
    public sealed class PersonalService : MutablePhotoService<Personal>
    {
        public PersonalService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Contact/Personal"; }
        }
    }
}