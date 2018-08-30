namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes a Currency resource
    /// </summary>
    public class Currency : BaseEntity
    {
        /// <summary>
        /// Code assigned
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name assigned
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// The exchange rate for the Currency.
        /// </summary>
        public decimal CurrencyRate { get; set; }
    }
}