using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;
using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/Invoice/TimeBilling's Lines
    /// </summary>
    public class TimeBillingInvoiceLine : InvoiceLine
    {
        /// <summary>
        /// The date the service/item was provided
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// The hours spent doing the <see cref="TimeBillingInvoiceLine.Activity"/>
        /// </summary>
        public decimal? Hours { get; set; }

        /// <summary>
        /// The <see cref="MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling.Activity"/> being performed
        /// </summary>
        public ActivityLink Activity { get; set; }

        /// <summary>
        /// The number of Units of the <see cref="TimeBillingInvoiceLine.Item"/>
        /// </summary>
        public decimal? Units { get; set; }

        /// <summary>
        /// The <see cref="MYOB.AccountRight.SDK.Contracts.Version2.Inventory.Item"/> being supplied
        /// </summary>
        public ItemLink Item { get; set; }

        /// <summary>
        /// The rate (if activity) or cost (if item) per hour or unit
        /// </summary>
        public decimal? Rate { get; set; }
    }
}