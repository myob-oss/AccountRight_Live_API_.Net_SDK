using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Purchase/Bill/Professional's Lines
    /// </summary>
    public class ProfessionalBillLine : BillLine
    {
        /// <summary>
        /// Date of purchase professional bill line
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Account of purchase professional bill line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}