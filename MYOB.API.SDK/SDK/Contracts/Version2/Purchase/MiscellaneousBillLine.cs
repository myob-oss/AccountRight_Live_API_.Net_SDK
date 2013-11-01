using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/Bill/Miscellaneous's Lines
    /// </summary>
    public class MiscellaneousBillLine : BillLine
    {
        /// <summary>
        /// Account of purchase miscellaneous bill line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}
