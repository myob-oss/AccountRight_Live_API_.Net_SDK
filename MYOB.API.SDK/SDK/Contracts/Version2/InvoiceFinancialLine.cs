using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    public class InvoiceFinancialLine : InvoiceLine
    {
        public DateTime? Date { get; set; }
        public AccountLink Account { get; set; }
    }
}