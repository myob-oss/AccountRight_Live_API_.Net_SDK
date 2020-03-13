using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/Invoice/Service line
    /// </summary>
    public class ServiceInvoiceLine : InvoiceLine
    {
        /// <summary>
        /// Transaction date entry, format YYYY-MM-DD HH:MM:SS
        /// <para>{ 'Date': '2013-09-10 13:33:02' }</para>
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Account for service invoice line
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Unit of Measure
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Unit Count
        /// </summary>
        public decimal? UnitCount { get; set; }

        /// <summary>
        /// Unit Amount
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Unit Amount for foreign currency
        /// </summary>
        public decimal? UnitPriceForeign { get; set; }

        /// <summary>
        /// Discount in percentage
        /// </summary>
        public decimal? DiscountPercent { get; set; }
    }
}