using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Item Price Matrix
    /// </summary>
    public class ItemPriceMatrix : BaseEntity
    {
        /// <summary>
        /// Link to the item
        /// </summary>
        public ItemLink Item { get; set; }

        /// <summary>
        /// Selling prices
        /// </summary>
        public IEnumerable<SellingPrice> SellingPrices { get; set; }
    }
}