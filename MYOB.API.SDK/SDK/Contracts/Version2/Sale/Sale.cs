using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class Sale : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
        public CardLink Customer { get; set; }
        public DateTime? PromisedDate { get; set; }
        public decimal BalanceDueAmount { get; set; }
        public SaleStatus Status { get; set; }

    }
}