using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    public class TaxCode : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public AccountLink TaxCollectedAccount { get; set; }
        public AccountLink TaxPaidAccount { get; set; }
        public AccountLink WithHoldingCreditAccount { get; set; }
        public AccountLink WithHoldingPayableAccount { get; set; }
        public AccountLink ImportDutyPayableAccount { get; set; }
        public SupplierLink LinkedSupplier { get; set; }
        public decimal LuxuryCarTaxThreshold { get; set; }
    }
}