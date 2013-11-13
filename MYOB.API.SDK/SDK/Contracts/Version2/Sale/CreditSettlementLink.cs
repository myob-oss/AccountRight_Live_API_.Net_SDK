namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Link to the CreditSettlement resource
    /// </summary>
    public class CreditSettlementLink : BaseLink
    {
        /// <summary>
        /// The number of the settlement
        /// </summary>
        public string Number { get; set; }
    }
}
