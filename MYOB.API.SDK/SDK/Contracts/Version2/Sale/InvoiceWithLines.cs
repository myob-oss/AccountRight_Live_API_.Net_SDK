using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    public class InvoiceWithLines<T> : Invoice where T : InvoiceLine
    {
        public IEnumerable<T> Lines { get; set; }
    }
}