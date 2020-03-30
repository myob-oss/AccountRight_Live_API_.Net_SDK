using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a line for an <see cref="ItemOrder"/>
    /// </summary>
    public class ItemOrderLine : OrderLine
    {
        /// <summary>
        /// The quanity to be shipped
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal ShipQuantity { get; set; }

        /// <summary>
        /// The unit price (depends on the value of <see cref="Order.IsTaxInclusive"/> in the parent <see cref="Order"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The foreign currency unit price (depends on the value of <see cref="Order.IsTaxInclusive"/> in the parent <see cref="Order"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal? UnitPriceForeign { get; set; }

        /// <summary>
        /// The dicount applied
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// The line amount (depends on the value of <see cref="Order.IsTaxInclusive"/> in the parent <see cref="Order"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal Total { get; set; }


        /// <summary>
        /// The foreign currency line amount (depends on the value of <see cref="Order.IsTaxInclusive"/> in the parent <see cref="Order"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
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
        /// The location
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public LocationLink Location { get; set; }
    }
}