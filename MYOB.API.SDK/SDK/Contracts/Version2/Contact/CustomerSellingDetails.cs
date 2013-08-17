using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{

    public class CustomerSellingDetails
    {
        public InvoiceLayoutType SaleLayout { get; set; }
        public DocumentAction? InvoiceDelivery { get; set; }
        public string PrintedForm { get; set; }
        public string ItemPriceLevel { get; set; }
        public AccountLink IncomeAccount { get; set; }
        public string ReceiptMemo { get; set; }
        public EmployeeLink SalesPerson { get; set; }
        public string SaleComment { get; set; }
        public string ShippingMethod { get; set; }
        public decimal HourlyBillingRate { get; set; }
        public string ABN { get; set; }
        public string ABNBranch { get; set; }
        public TaxCodeLink TaxCode { get; set; }
        public TaxCodeLink FreightTaxCode { get; set; }
        public bool UseCustomerTaxCode { get; set; }
        public CustomerTerms Terms { get; set; }
        public CustomerCredit Credit { get; set; }
        public string TaxIdNumber { get; set; }
        public string Memo { get; set; }
    }
}