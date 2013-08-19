using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{

    public class SupplierBuyingDetails
    {
        public PurchaseLayoutType PurchaseLayout { get; set; }

        public string PrintedForm { get; set; }

        public DocumentAction? PurchaseOrderDelivery { get; set; }

        public AccountLink ExpenseAccount { get; set; }

        public string PaymentMemo { get; set; }

        public string PurchaseComment { get; set; }

        public decimal SupplierBillingRate { get; set; }

        public string ShippingMethod { get; set; }

        public bool IsReportable { get; set; }

        public decimal CostPerHour { get; set; }

        public SupplierCredit Credit { get; set; }

        public string ABN { get; set; }

        public string ABNBranch { get; set; }

        public string TaxIdNumber { get; set; }

        public TaxCodeLink TaxCode { get; set; }

        public TaxCodeLink FreightTaxCode { get; set; }

        public bool UseSupplierTaxCode { get; set; }

        public SupplierTerms Terms { get; set; }
    }
}