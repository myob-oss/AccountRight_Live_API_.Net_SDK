using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Target Sale used for discount calculation
    /// </summary>
    public class CalculateDiscountsFeesSale
    {
        /// <summary>
        /// Unique identifier of the sale
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Type of sale
        /// <para>Invoice</para>
        /// </summary>
        public CalculateDiscountsFeesSaleType Type { get; set; }
    }
}
