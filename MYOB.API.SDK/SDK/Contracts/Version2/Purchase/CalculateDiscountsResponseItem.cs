using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/SupplierPayment/CalculateDiscounts response item
    /// </summary>
    public class CalculateDiscountsResponseItem
    {
        /// <summary>
        /// Unique id to allow you to identify the discount calculated item
        /// </summary>
        public int RequestID { get; set; }

        /// <summary>
        /// Purchase use for calculation
        /// </summary>
        public CalculateDiscountsPurchase Purchase { get; set; }

        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Calculated discount
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Calculated foreign discount amount (null if not foreign transaction)
        /// </summary>
        public decimal? DiscountForeign { get; set; }

        /// <summary>
        /// Discount expiry date
        /// </summary>
        public DateTime DiscountExpiryDate { get; set; }

        /// <summary>
        /// Balance due date
        /// </summary>
        public DateTime BalanceDueDate { get; set; }

        /// <summary>
        /// Balance due amount
        /// </summary>
        public decimal BalanceDue { get; set; }

        /// <summary>
        /// Foreign Balance due amount (null if not foreign transaction)
        /// </summary>
        public decimal? BalanceDueForeign { get; set; }
    }
}
