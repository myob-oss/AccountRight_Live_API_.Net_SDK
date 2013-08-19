using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class MiscellaneousInvoice : InvoiceWithLines<MiscellaneousInvoiceLine>
    {
        public MiscellaneousInvoice()
        {
            IsTaxInclusive = true;
        }

        public InvoiceTerms Terms { get; set; }
        public bool IsTaxInclusive { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }
        public CardLink Salesperson { get; set; }
        public string JournalMemo { get; set; }
        public string ReferralSource { get; set; }
    }
}