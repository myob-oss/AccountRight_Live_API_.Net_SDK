namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    public class Terms
    {
        public TermsPaymentType PaymentIsDue { get; set; }

        public int DiscountDate { get; set; }

        public int BalanceDueDate { get; set; }

        public double DiscountForEarlyPayment { get; set; }

    }
}