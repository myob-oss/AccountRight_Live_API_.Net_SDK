namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    public class SupplierPaymentLine
    {
        public int RowID { get; set; }

        public SupplierPaymentLineType Type { get; set; }

        public PurchaseLink Purchase { get; set; }

        public decimal AmountApplied { get; set; }

        public decimal DiscountApplied { get; set; }

        public long RowVersion { get; set; }
    }

    public class PurchaseLink : BaseLink
    {
        public string Number { get; set; }
    }

    public enum SupplierPaymentLineType
    {
        Bill,
        Order
    }
}