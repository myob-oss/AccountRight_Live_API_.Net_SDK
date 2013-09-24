using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    public class SupplierPayment : BaseEntity
    {
        public SupplierPayment()
        {
            PayFrom = PayFrom.Account;
            Date = DateTime.Now;
        }

        public PayFrom PayFrom { get; set; }
        public AccountLink Account { get; set; }
        public SupplierLink Supplier { get; set; }

        public DateTime Date { get; set; }
        
        public decimal AmountPaid { get; set; }
        public string Memo { get; set; }

        public string PayeeAddress { get; set; }

        public string StatementParticulars { get; set; }

        /// <summary>
        /// Statement Code (New Zealand only)
        /// </summary>
        public string StatementCode { get; set; }

        /// <summary>
        /// Statement Reference (New Zealand only)
        /// </summary>
        public string StatementReference { get; set; }

        public string PaymentNumber { get; set; }

        public DocumentAction DeliveryStatus { get; set; }

        public IEnumerable<SupplierPaymentLine> Lines { get; set; }
    }
}
