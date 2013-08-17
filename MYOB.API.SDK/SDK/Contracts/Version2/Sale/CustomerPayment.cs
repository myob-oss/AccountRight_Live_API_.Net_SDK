using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class CustomerPayment : BaseEntity
    {
        public CustomerPayment()
        {
            DepositTo = DepositTo.Account;
            Date = DateTime.Now;
        }

        public DepositTo DepositTo { get; set; }
        public AccountLink Account { get; set; }
        public CardLink Customer { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal AmountReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string Memo { get; set; }
        public IEnumerable<CustomerPaymentLine> Invoices { get; set; }
    }
}