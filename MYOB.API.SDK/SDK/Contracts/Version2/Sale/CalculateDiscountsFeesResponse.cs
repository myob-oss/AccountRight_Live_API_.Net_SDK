using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{

    /// <summary>
    /// Describe the Sale/CustomerPayment/CalculateDiscountsFees response
    /// </summary>
    public class CalculateDiscountsFeesResponse
    {
        /// <summary>
        /// Collection of discount calculated item
        /// </summary>
        public IEnumerable<CalculateDiscountsFeesResponseItem> Items { get; set; } 
    }
}
