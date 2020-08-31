using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    ///     General Journal
    /// </summary>
    public class GeneralJournal : BaseEntity
    {
        /// <summary>
        /// The display ID
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        ///     Date occurred
        /// </summary>
        public DateTime DateOccurred { get; set; }

        /// <summary>
        ///     Lines Amount is Tax Inclusive
        /// </summary>
        public bool IsTaxInclusive { get; set; }

        /// <summary>
        ///     Journal Memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Entry in this field is mandatory.
        /// </summary>
        public GSTReportingMethod GSTReportingMethod { get; set; }

        /// <summary>
        ///     Year End Adjustment
        /// </summary>
        public bool IsYearEndAdjustment { get; set; }

        /// <summary>
        ///     Category Id
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        ///     Lines
        /// </summary>
        public IList<GeneralJournalLine> Lines { get; set; }

        /// <summary>
        ///     Null is no foreign currency is set
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }
       
        /// <summary>
        /// The exchange rate between the Local and Foreign currency.
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }
    }
}