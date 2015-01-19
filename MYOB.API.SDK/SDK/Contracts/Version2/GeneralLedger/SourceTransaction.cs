namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    ///  Source transaction details
    /// </summary>
    public class SourceTransaction : BaseLink
    {
        /// <summary>
        /// Entity transaction relates to
        /// </summary>
        public string TransactionType { get; set; }
    }
}