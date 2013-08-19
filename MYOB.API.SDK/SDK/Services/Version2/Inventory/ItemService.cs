using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;

namespace MYOB.AccountRight.SDK.Services.Inventory
{
    public sealed class ItemService : MutablePhotoService<Item>
    {
        public ItemService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Inventory/Item"; }
        }
    }
}