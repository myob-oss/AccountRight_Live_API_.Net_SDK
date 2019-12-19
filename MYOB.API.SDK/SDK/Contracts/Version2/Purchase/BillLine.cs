using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Common class for purchase bill line
    /// </summary>
    public class BillLine
    {
        /// <summary>
        /// Sequence of the entry within the item purchase set. 
        /// <para>ONLY required for updating an existing purchase bill line.</para>
        /// <para>NOT required when creating a new purchase bill.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// Bill line type, can consist of the following:
        /// <para>Transaction</para>
        /// <para>Header</para>
        /// <para>SubTotal</para>
        /// </summary>
        public InvoiceLineType Type { get; set; }

        /// <summary>
        /// Description text for the purchase line.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Total amount for the line only.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Total amount for the line only.
        /// </summary>
        public decimal? TotalForeign { get; set; }
        /// <summary>
        /// Job of the purchase line.
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// Tax code of the purchase line.
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time. 
        /// <para>ONLY required for updating an existing item purchase bill line.</para>
        /// <para>NOT required when creating a new item purchase bill.</para>
        /// </summary>
        public string RowVersion { get; set; }
    }
}
