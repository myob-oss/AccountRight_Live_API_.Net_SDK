using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/Bill/Service's Lines
    /// </summary>
    public class ServiceBillLine : BillLine
    {
        /// <summary>
        /// Unit Count of UnitOfMeasure
        /// </summary>
        public decimal? UnitCount { get; set; }

        /// <summary>
        /// Unit for Measure
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Account of purchase service bill line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}
