using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/CustomerPayment's resource line
    /// </summary>
    public class CustomerPaymentLine
    {
        /// <summary>
        /// Sequence of the entry within the customer payment set.
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// Sales invoice number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Unique guid identifier belonging to the invoice assigned to the customer payment.
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Amount applied to sale.
        /// </summary>
        public decimal AmountApplied { get; set; }
        /// <summary>
        /// Foreign Amount applied to sale.
        /// </summary>
        public decimal? AmountAppliedForeign { get; set; }

        /// <summary>
        /// Any gain or loss made on this sale due to exchange rate differences.
        /// </summary>
        public decimal? GainOrLoss { get; set; }

        /// <summary>
        /// The customer payment line type
        /// </summary>
        public CustomerPaymentLineType Type { get; set; }

        /// <summary>
        /// Uniform resource identifier associated with the invoice object.
        /// </summary>
        public Uri Uri { get; set; }
    }
}