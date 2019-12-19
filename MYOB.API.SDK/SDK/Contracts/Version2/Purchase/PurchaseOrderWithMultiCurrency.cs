using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Descibes a subclassed <see cref="PurchaseOrderWithLines{TOrderLine}"/> that has that has multi-currency properties
    /// </summary>
    /// <typeparam name="TOrderLine"></typeparam>
    public abstract class PurchaseOrderWithMultiCurrencySupport<TOrderLine> : PurchaseOrderWithLines<TOrderLine>
        where TOrderLine : OrderLine
    {
        /// <summary>
        /// Sum of all tax exclusive foreign currency line amounts applicable to the sale invoice.
        /// </summary>
        public decimal? SubtotalForeign { get; set; }

        /// <summary>
        /// Tax freight foreign currency amount applicable to the sale order.
        /// </summary>
        /// <remarks>
        /// Only supported by Item or Service orders.
        /// </remarks>
        public decimal? FreightForeign { get; set; }

        /// <summary>
        /// Total of all foreign currency tax amounts applicable to the sale invoice.
        /// </summary>
        public decimal? TotalTaxForeign { get; set; }

        /// <summary>
        /// Total foreign currency amount of the sale invoice.
        /// </summary>
        public decimal? TotalAmountForeign { get; set; }

        /// <summary>
        /// The foreign currency amount paid to date.
        /// </summary>
        public decimal? AppliedToDateForeign { get; set; }

        /// <summary>
        /// The foreign currency balance due amount.
        /// </summary>
        public decimal? BalanceDueAmountForeign { get; set; }
    }
}