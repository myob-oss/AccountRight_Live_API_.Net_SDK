namespace MYOB.AccountRight.SDK.Contracts.Version2
{

    public class CustomerTerms : Terms
    {
        public double MonthlyChargeForLatePayment { get; set; }
        public double VolumeDiscount { get; set; }
    }
}