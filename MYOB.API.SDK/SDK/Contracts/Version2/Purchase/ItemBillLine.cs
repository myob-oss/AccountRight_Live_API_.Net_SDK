using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    public class ItemBillLine: BillLine
    {
        public decimal BillQuantity { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal BackorderQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public ItemLink Item { get; set; }
    }
}
