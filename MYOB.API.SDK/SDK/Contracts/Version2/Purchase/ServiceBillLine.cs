using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/Bill/Service's Lines
    /// </summary>
    public class ServiceBillLine : BillLine
    {
        /// <summary>
        /// Account of purchase service bill line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}
