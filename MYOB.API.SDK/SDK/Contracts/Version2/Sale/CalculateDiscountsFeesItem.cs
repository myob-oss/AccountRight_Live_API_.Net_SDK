using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/CustomerPayment/CalculateDiscountsFees request's item
    /// </summary>
    public class CalculateDiscountsFeesItem
    {
        /// <summary>
        /// Unique id to allow you to identify the discount calculated item
        /// </summary>
        public int RequestID { get; set; }

        /// <summary>
        /// Sale to use for discount calculation
        /// </summary>
        public CalculateDiscountsFeesSale Sale { get; set; }

        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }
    }
}
