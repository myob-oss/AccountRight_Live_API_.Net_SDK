using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/SupplierPayment/CalculateDiscounts response
    /// </summary>
    public class CalculateDiscountsResponse
    {
        /// <summary>
        /// Collection of discount calculated item
        /// </summary>
        public IEnumerable<CalculateDiscountsResponseItem> Items { get; set; }
    }
}
