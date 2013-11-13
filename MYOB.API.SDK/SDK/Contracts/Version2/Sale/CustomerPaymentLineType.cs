namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Type of CustomerPaymentLine resource
    /// </summary>
    public enum CustomerPaymentLineType
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
        /// Purged sale type
        /// </summary>
        Purged
    }
}
