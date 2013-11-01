namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Type of Invoice
    /// </summary>
    public enum InvoiceLayoutType
    {
        /// <summary>
        /// NoDefaults
        /// </summary>
        NoDefault,
        
        /// <summary>
        /// Service
        /// </summary>
        Service,
        
        /// <summary>
        /// Item
        /// </summary>
        Item,
        
        /// <summary>
        /// Professional
        /// </summary>
        Professional,
        
        /// <summary>
        /// Time Billing
        /// </summary>
        TimeBilling,
        
        /// <summary>
        /// Miscellaneous
        /// </summary>
        Miscellaneous,

        /// <summary>
        /// A preconversion invoice is readonly
        /// </summary>
        PreConversion,

    }
}