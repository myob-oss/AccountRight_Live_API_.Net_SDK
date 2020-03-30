using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale Invoice's terms
    /// </summary>
    public class InvoiceTerms : Terms
    {
        /// <summary>
        /// % monthly charge for late payment.
        /// </summary>
        public double MonthlyChargeForLatePayment { get; set; }

        /// <summary>
        /// The date the discount (if exists) will expire.
        /// </summary>
        /// <remarks>
        /// Available from 2013.5 (cloud), 2014.1 (desktop)
        /// </remarks>
        public DateTime? DiscountExpiryDate { get; set; }

        /// <summary>
        /// The discount applicable if the amount if paid before the discount expiry date
        /// </summary>
        /// <remarks>
        /// Available from 2013.5 (cloud), 2014.1 (desktop)
        /// </remarks>
        public decimal? Discount { get; set; }
        /// <summary>
        /// The discount applicable in foreign currency if the amount if paid before the discount expiry date
        /// </summary>
        public decimal? DiscountForeign { get; set; }

        /// <summary>
        /// Date the invoice balance is due.
        /// </summary>
        /// <remarks>
        /// Available from 2013.5 (cloud), 2014.1 (desktop)
        /// </remarks>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Finance Charge amount applicable to the invoice.
        /// </summary>
        /// <remarks>
        /// Available from 2013.5 (cloud), 2014.1 (desktop)
        /// </remarks>
        public decimal? FinanceCharge { get; set; }
        /// <summary>
        /// Finance Charge amount in foreign currency applicable to the invoice.
        /// </summary>
        public decimal? FinanceChargeForeign { get; set; }
    }
}