namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Selling price
    /// </summary>
    public class SellingPrice
    {
        /// <summary>
        /// Quantity over
        /// </summary>
        public float QuantityOver { get; set; }

        /// <summary>
        /// Prices to use when price is over <see cref="QuantityOver"/>
        /// </summary>
        public Levels Levels { get; set; }
    }
}