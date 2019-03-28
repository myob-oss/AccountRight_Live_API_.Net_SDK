using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Common class for sale bill line
    /// </summary>
    public class InvoiceLine
    {
        /// <summary>
        /// Sequence of the entry within the item sale set. 
        /// <para>ONLY required for updating an existing item sale line.</para>
        /// <para>NOT required when creating a new item sale invoice.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// Invoice line type, can consist of the following:
        /// <para>Transaction</para>
        /// <para>Header</para>
        /// <para>SubTotal</para>
        /// </summary>
        public InvoiceLineType Type { get; set; }

        /// <summary>
        /// Description text for the sale line.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Total amount for the line only.
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Total amount in foreign currency for the line only.
        /// </summary>
        public decimal? TotalForeign { get; set; }

        /// <summary>
        /// Job for the line
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// TaxCode for the line
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time.
        /// <para>ONLY required for updating an existing sale line.</para>
        /// <para>NOT required when creating a new sale invoice.</para>
        /// </summary>
        public string RowVersion { get; set; }
    }
}