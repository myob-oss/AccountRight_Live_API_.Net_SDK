namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes the basic quote line types
    /// </summary>
    public enum QuoteLineType
    {
        /// <summary>
        /// Used by all
        /// </summary>
        Transaction,

        /// <summary>
        /// Can be used by all Quote types
        /// </summary>
        Header,

        /// <summary>
        /// Can be used by all Quote types
        /// </summary>
        SubTotal,
    }
}