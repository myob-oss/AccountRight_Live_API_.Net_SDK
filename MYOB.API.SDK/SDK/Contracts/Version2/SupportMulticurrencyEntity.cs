using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Base entity with ForeignCurrency currency link
    /// </summary>
    public class SupportMulticurrencyEntity : BaseEntity
    {
        /// <summary>
        /// The Foreign Currency associated with the entity
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// The exchange rate (to local) of ForeignCurrency related to this supplier payment
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }
    }
}