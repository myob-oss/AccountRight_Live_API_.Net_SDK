using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{

    /// <summary>
    /// Describe the Sale/CustomerPayment/CalculateDiscountsFees response item
    /// </summary>
    public class CalculateDiscountsFeesResponseItem
    {
        /// <summary>
        /// Unique id to allow you to identify the discount calculated item
        /// </summary>
        public int RequestID { get; set; }

        /// <summary>
        /// Sale use for calculation
        /// </summary>
        public CalculateDiscountsFeesSale Sale { get; set; }
        
        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Calculated discount
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Discount expiry date
        /// </summary>
        public DateTime DiscountExpiryDate { get; set; }

        /// <summary>
        /// Calculated finance charges
        /// </summary>
        public decimal FinanceCharge { get; set; }

        /// <summary>
        /// Balance due date
        /// </summary>
        public DateTime BalanceDueDate { get; set; }

        /// <summary>
        /// Balance due amount
        /// </summary>
        public decimal BalanceDue { get; set; }
    }
}
