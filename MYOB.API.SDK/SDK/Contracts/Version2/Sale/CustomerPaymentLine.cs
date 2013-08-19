using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class CustomerPaymentLine
    {
        public int RowID { get; set; }
        public string Number { get; set; }
        public Guid UID { get; set; }
        public decimal AmountApplied { get; set; }
        public decimal DiscountApplied { get; set; }
        public Uri Uri { get; set; }
    }
}