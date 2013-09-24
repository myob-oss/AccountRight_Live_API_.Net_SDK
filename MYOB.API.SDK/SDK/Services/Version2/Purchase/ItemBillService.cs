using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;

namespace MYOB.AccountRight.SDK.Services.Purchase
{
    public class ItemBillService: MutableService<ItemBill>
    {
        public ItemBillService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Purchase/Bill/Item"; }
        }
    }
}
