using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a line for a <see cref="MiscellaneousQuote"/>
    /// </summary>
    public class MiscellaneousQuoteLine : QuoteLine
    {
        /// <summary>
        /// The line amount (depends on the value of <see cref="Quote.IsTaxInclusive"/> in the parent <see cref="Quote"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public decimal Total { get; set; }

        /// <summary>
        /// The account
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The job
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public JobLink Job { get; set; }

        /// <summary>
        /// The applied tax code
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public TaxCodeLink TaxCode { get; set; }
    }
}