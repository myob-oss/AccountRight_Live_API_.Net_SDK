namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Type of CreditSettlementLine
    /// </summary>
    public enum CreditSettlementLineType
    {
        /// <summary>
        /// Sale invoice type
        /// </summary>
        Invoice,
        
        /// <summary>
        /// Sale order type
        /// </summary>
        Order,

        /// <summary>
        /// Purged invoice type
        /// </summary>
        Purged
    }
}