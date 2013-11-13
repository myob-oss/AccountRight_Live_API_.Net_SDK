using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/SupplierPayment/CalculateDiscounts request
    /// </summary>
    public class CalculateDiscounts
    {
        /// <summary>
        /// Collection of item required to do discount calculation
        /// </summary>
        public IEnumerable<CalculateDiscountsItem> Items { get; set; }
    }
}
