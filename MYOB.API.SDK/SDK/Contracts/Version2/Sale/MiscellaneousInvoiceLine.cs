using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/Invoice/Miscellaneous line
    /// </summary>
    public class MiscellaneousInvoiceLine : InvoiceLine
    {
        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// <para>{ 'Date': '2013-09-10 13:33:02' }</para>
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Account for miscellaneous invoice line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}