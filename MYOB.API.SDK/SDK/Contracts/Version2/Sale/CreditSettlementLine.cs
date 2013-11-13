namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/CreditSettlement's line
    /// </summary>
    public class CreditSettlementLine
    {
        /// <summary>
        /// Indicates whether the settlement was to an Invoice or Order
        /// </summary>
        public CreditSettlementLineType Type { get; set; }

        /// <summary>
        /// A link to the applied Invoice or Order
        /// </summary>
        public SaleLink Sale { get; set; }

        /// <summary>
        /// The amount applied to the Invoice or Order
        /// </summary>
        public decimal AmountApplied { get; set; }      
    }
}