namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes the different quote types
    /// </summary>
    public enum QuoteLayoutType
    {
        /// <summary>
        /// The quote is a <see cref="ServiceQuote"/>
        /// </summary>
        Service,

        /// <summary>
        /// The quote is an <see cref="ItemQuote"/>
        /// </summary>
        Item,

        /// <summary>
        /// The quote is a <see cref="ProfessionalQuote"/>
        /// </summary>
        Professional,

        /// <summary>
        /// The quote is a <see cref="MiscellaneousQuote"/>
        /// </summary>
        Miscellaneous,

        /// <summary>
        /// The quote is a <see cref="TimeBillingQuote"/>
        /// </summary>
        TimeBilling,
    }
}