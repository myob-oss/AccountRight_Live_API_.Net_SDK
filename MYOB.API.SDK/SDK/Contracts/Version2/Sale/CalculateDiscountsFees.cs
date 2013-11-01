using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/CustomerPayment/CalculateDiscountsFees request
    /// </summary>
    public class CalculateDiscountsFees
    {
        /// <summary>
        /// Collection of item required to do discount calculation
        /// </summary>
        public IEnumerable<CalculateDiscountsFeesItem> Items { get; set; }
    }
}
