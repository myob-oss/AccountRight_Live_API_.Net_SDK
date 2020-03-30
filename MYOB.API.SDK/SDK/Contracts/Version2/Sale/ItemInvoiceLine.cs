using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/Invoice/Item's Lines
    /// </summary>
    public class ItemInvoiceLine : InvoiceLine
    {
        /// <summary>
        /// The quantity of goods shipped.
        /// </summary>
        public decimal ShipQuantity { get; set; }

        /// <summary>
        /// Unit price assigned to the item.
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Unit price assigned to the item in foreign currency.
        /// </summary>
        public decimal? UnitPriceForeign { get; set; }

        /// <summary>
        /// Discount rate applicable to the line of the sale invoice.
        /// </summary>
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// Dollar amount posted to the Asset account setup on an item using 'I Inventory'
        /// </summary>
        public decimal CostOfGoodsSold { get; set; }

        /// <summary>
        /// Item for the invoice line
        /// </summary>
        public ItemLink Item { get; set; }

        /// <summary>
        /// Location of the purchase item bill line
        /// </summary>
        public LocationLink Location { get; set; }

        /// <summary>
        /// Unit of Measure
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Unit Count
        /// </summary>
        public decimal? UnitCount { get; set; }

        /// <summary>
        /// Item for the invoice line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}