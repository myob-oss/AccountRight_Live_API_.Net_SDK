using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes an AccountingProperties resource
    /// </summary>
    public class AccountingProperties 
    {
        /// <summary>
        /// Starting date for the company file. Conversion date must always be for the first day of the selected month. You can't record transactions dated earlier than the conversion date.
        /// </summary>
        public DateTime ConversionDate { get; set; }

        /// <summary>
        /// Year that the current financial year ends. For example, 2014 indicates that the financial year ends in 2014.
        /// </summary>
        public int CurrentFinancialYear { get; set; }

        /// <summary>
        /// Number representing the last month of the financial year. For example, 3 indicates March.
        /// </summary>
        public int LastMonthFinancialYear { get; set; }
    }
}