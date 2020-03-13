using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a line for an <see cref="ItemQuote"/>
    /// </summary>
    public class ItemQuoteLine : QuoteLine
    {
        /// <summary>
        /// The quanity to be shipped
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public decimal ShipQuantity { get; set; }

        /// <summary>
        /// The unit price (depends on the value of <see cref="Quote.IsTaxInclusive"/> in the parent <see cref="Quote"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The dicount applied
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// The line amount (depends on the value of <see cref="Quote.IsTaxInclusive"/> in the parent <see cref="Quote"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public decimal Total { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="QuoteLine.Type"/>=<see cref="QuoteLineType.Transaction"/>
        /// </remarks>
        public ItemLink Item { get; set; }

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

        /// <summary>
        /// Unit of Measure
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Unit Count
        /// </summary>
        public decimal? UnitCount { get; set; }

        /// <summary>
        /// Item for the invoice line
        /// </summary>
        public AccountLink Account { get; set; }
    }
}