using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// A receive money transaction line entity
    /// </summary>
    public class ReceiveMoneyTxnLine
    {
        /// <summary>
        /// Sequence of the entry within the receive money transaction set. 
        /// <para>ONLY required for updating an existing receive money transaction line.</para>
        /// <para>NOT required when creating a new receive money transaction.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// Account for receive money transaction line
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Job for receive money transaction line
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
	    /// Tax Code for receive money transaction line
    	/// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Memo for receive money transaction line
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Amount for receive money transaction line
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The quantity amount for this line
        /// </summary>
        public decimal? UnitCount { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time. 
        /// <para>ONLY required for updating an existing receive money transaction.</para>
        /// <para>NOT required when creating a new receive money transaction.</para>
        /// </summary>
        public long RowVersion { get; set; }
    }
}
