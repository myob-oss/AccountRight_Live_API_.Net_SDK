namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Base resource for terms definitions
    /// </summary>
    public class Terms
    {
        /// <summary>
        /// Default Terms of Payment definitions:
        /// </summary>
        public TermsPaymentType PaymentIsDue { get; set; }

        /// <summary>
        /// The discount date which includes EOM (End of Month).
        /// </summary>
        public int DiscountDate { get; set; }

        /// <summary>
        /// The balance due date which includes EOM (End of Month).
        /// </summary>
        public int BalanceDueDate { get; set; }

        /// <summary>
        /// % discount for early payment.
        /// </summary>
        public double DiscountForEarlyPayment { get; set; }

    }
}