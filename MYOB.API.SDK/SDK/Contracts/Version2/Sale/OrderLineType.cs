namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes the basic order line types
    /// </summary>
    public enum OrderLineType
    {
        /// <summary>
        /// Used by all
        /// </summary>
        Transaction,

        /// <summary>
        /// Can be used by all Order types
        /// </summary>
        Header,

        /// <summary>
        /// Can be used by all Order types
        /// </summary>
        SubTotal,
    }
}