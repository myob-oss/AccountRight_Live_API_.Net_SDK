namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale invoice's terms
    /// </summary>
    public class InvoiceTerms : Terms
    {
        /// <summary>
        /// % monthly charge for late payment.
        /// </summary>
        public double MonthlyChargeForLatePayment { get; set; }
    }
}