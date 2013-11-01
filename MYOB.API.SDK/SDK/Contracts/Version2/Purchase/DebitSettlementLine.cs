namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/DebitSettlement's line
    /// </summary>
    public class DebitSettlementLine
    {
        /// <summary>
        /// Indicates whether the settlement was to a Bill or an Order
        /// </summary>
        public DebitSettlementLineType Type { get; set; }

        /// <summary>
        /// A link to the applied Bill or Order
        /// </summary>
        public PurchaseLink Purchase { get; set; }

        /// <summary>
        /// The amount applied to the Bill or Order
        /// </summary>
        public decimal AmountApplied { get; set; }
    }
}