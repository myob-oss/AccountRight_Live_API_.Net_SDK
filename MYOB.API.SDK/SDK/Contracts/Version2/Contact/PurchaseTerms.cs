using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes additional terms for a purchase
    /// </summary>
    public class PurchaseTerms : Terms
    {
        /// <summary>
        /// The date the discount (if exists) will expire.
        /// </summary>
        public DateTime? DiscountExpiryDate { get; set; }

        /// <summary>
        /// The discount applicable if the amount if paid before the discount expiry date
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// The foreign currency discount applicable if the amount if paid before the discount expiry date
        /// </summary>
        public decimal? DiscountForeign { get; set; }

        /// <summary>
        /// Date the balance is due.
        /// </summary>
        public DateTime? DueDate { get; set; }
    }
}