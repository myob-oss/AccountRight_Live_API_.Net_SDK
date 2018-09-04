using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a line for a <see cref="ProfessionalQuote"/>
    /// </summary>
    public class ProfessionalQuoteLine : QuoteLine
    {
        /// <summary>
        /// The date         
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public DateTime? Date { get; set; }

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