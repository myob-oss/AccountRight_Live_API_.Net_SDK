namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    public class CustomerPaymentDetails
    {
        public string Method { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string BSBNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string Notes { get; set; }
    }
}