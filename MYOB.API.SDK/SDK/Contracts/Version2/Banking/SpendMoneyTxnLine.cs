using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// A spend money transaction line entity
    /// </summary>
    public class SpendMoneyTxnLine
    {
        /// <summary>
        /// Sequence of the entry within the spend money transaction set. 
        /// <para>ONLY required for updating an existing spend money transaction line.</para>
        /// <para>NOT required when creating a new spend money transaction.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// Account for spend money transaction line
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Job for spend money transaction line
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// Tax Code for spend money transaction line
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Amount for spend money transaction line
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Memo for spend money transaction line
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The quantity amount for this line
        /// </summary>
        public decimal? UnitCount { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time. 
        /// <para>ONLY required for updating an existing spend money transaction.</para>
        /// <para>NOT required when creating a new spend money transaction.</para>
        /// </summary>
        public long RowVersion { get; set; }        
    }
}