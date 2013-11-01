using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/SupplierPayment/CalculateDiscounts request's item
    /// </summary>
    public class CalculateDiscountsItem
    {
        /// <summary>
        /// Unique id to allow you to identify the discount calculated item
        /// </summary>
        public int RequestID { get; set; }

        /// <summary>
        /// Purchase to use for discount calculation
        /// </summary>
        public CalculateDiscountsPurchase Purchase { get; set; }

        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }
    }
}
