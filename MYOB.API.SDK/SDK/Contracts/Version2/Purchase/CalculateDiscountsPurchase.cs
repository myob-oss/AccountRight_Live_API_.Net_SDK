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
    }
}
