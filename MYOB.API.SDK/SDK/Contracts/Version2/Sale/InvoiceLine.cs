using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class InvoiceLine
    {
        public int RowID { get; set; }
        public InvoiceLineType Type { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public JobLink Job { get; set; }
        public TaxCodeLink TaxCode { get; set; }
        public string RowVersion { get; set; }
    }
}