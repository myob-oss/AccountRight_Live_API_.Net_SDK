using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describes a line for an <see cref="ItemPurchaseOrder"/>
    /// </summary>
    public class ItemPurchaseOrderLine : OrderLine
    {
        /// <summary>
        /// The quanity
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal BillQuantity { get; set; }

        /// <summary>
        /// Received quantity of this order
        /// </summary>
        public decimal ReceivedQuantity { get; set; }

        /// <summary>
        /// The unit price (depends on the value of <see cref="PurchaseOrder.IsTaxInclusive"/> in the parent <see cref="PurchaseOrder"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Unit price assigned to the item in foreign currency.
        /// </summary>
        public decimal? UnitPriceForeign { get; set; }

        /// <summary>
        /// The dicount applied
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// The line amount (depends on the value of <see cref="PurchaseOrder.IsTaxInclusive"/> in the parent <see cref="PurchaseOrder"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal Total { get; set; }

        /// <summary>
        /// Total amount in foreign currency for the line only.
        /// </summary>
        public decimal? TotalForeign { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public ItemLink Item { get; set; }

        /// <summary>
        /// The job
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public JobLink Job { get; set; }

        /// <summary>
        /// The applied tax code
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public LocationLink Location { get; set; }
    }
}