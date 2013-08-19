namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    public class SupplierPaymentDetails
    {

        public string BSBNumber { get; set; }

        public string BankAccountNumber { get; set; }

        public string BankAccountName { get; set; }

        public string StatementText { get; set; }

        public SupplierRefundDetails Refund { get; set; }
    }
}