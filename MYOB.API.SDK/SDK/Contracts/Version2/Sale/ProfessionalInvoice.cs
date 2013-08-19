using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class ProfessionalInvoice : InvoiceWithLines<ProfessionalInvoiceLine>
    {
        public ProfessionalInvoice()
        {
            IsTaxInclusive = true;
            InvoiceDeliveryStatus = DocumentAction.Print;
        }

        public InvoiceTerms Terms { get; set; }
        public bool IsTaxInclusive { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }
        public CardLink Salesperson { get; set; }
        public string Comment { get; set; }
        public string JournalMemo { get; set; }
        public string ReferralSource { get; set; }
        public DocumentAction InvoiceDeliveryStatus { get; set; }
    }
}