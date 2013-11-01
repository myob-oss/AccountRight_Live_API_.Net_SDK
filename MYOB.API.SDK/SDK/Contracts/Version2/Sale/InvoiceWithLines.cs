using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Common class for Professional, Miscelleneous, Service and Item sale invoice
    /// </summary>
    /// <typeparam name="T">Class that implement InvoiceLine</typeparam>
    public class InvoiceWithLines<T> : Invoice where T : InvoiceLine
    {
        /// <summary>
        /// Collection of sale invoice line
        /// </summary>
        public IEnumerable<T> Lines { get; set; }
    }
}