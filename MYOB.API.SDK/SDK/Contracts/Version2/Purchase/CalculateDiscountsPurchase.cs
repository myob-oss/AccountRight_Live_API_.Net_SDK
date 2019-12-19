using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Target purchase used for discount calculation
    /// </summary>
    public class CalculateDiscountsPurchase
    {
        /// <summary>
        /// Unique identifier of the purchase
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Type of purchase
        /// <para>Bill</para>
        /// </summary>
        public CalculateDiscountsPurchaseType Type { get; set; }

        /// <summary>
        /// Currency of Purchase (or null)
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// Exchange rate of currency (if foreign)
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }
    }
}
