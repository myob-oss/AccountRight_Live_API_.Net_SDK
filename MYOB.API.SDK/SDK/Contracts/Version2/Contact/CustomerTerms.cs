namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Additional customer terms
    /// </summary>
    public class CustomerTerms : Terms
    {
        /// <summary>
        /// % monthly charge for late payment.
        /// </summary>
        public double MonthlyChargeForLatePayment { get; set; }

        /// <summary>
        /// % Volume discount.
        /// </summary>
        public double VolumeDiscount { get; set; }
    }
}