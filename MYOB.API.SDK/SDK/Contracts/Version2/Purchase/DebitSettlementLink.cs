namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Link to the DebitSettlement resource
    /// </summary>
    public class DebitSettlementLink: BaseLink
    {
        /// <summary>
        /// The number of the settlement
        /// </summary>
        public string Number { get; set; }
    }
}
