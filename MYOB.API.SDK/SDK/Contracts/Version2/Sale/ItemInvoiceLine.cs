using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class ItemInvoiceLine : InvoiceLine
    {
        public decimal ShipQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public ItemLink Item { get; set; }
    }
}