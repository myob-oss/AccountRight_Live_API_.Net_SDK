namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Descibes a subclassed <see cref="Quote"/> that has lines
    /// </summary>
    /// <typeparam name="TQuoteLine"></typeparam>
    public abstract class QuoteWithLines<TQuoteLine> : Quote
        where TQuoteLine : QuoteLine
    {
        /// <summary>
        /// The lines for a subclassed <see cref="Quote"/>
        /// </summary>
        public TQuoteLine[] Lines { get; set; }
    }
}