using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class ServiceInvoice : InvoiceWithLines<ServiceInvoiceLine>
    {
        public ServiceInvoice()
        {
            IsTaxInclusive = true;
            InvoiceDeliveryStatus = DocumentAction.Print;
        }

        public string ShipToAddress { get; set; }
        public InvoiceTerms Terms { get; set; }
        public bool IsTaxInclusive { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Freight { get; set; }
        public TaxCodeLink FreightTaxCode { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }
        public CardLink Salesperson { get; set; }
        public string Comment { get; set; }
        public string ShippingMethod { get; set; }
        public string JournalMemo { get; set; }
        public string ReferralSource { get; set; }
        public DocumentAction InvoiceDeliveryStatus { get; set; }
    }
}