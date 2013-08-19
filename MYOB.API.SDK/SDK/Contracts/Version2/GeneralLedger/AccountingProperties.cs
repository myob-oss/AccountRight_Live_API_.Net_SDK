using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// AccountingProperties
    /// </summary>
    public class AccountingProperties 
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime ConversionDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentFinancialYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LastMonthFinancialYear { get; set; }
    }
}