using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Descibes a subclassed <see cref="Order"/> that has lines
    /// </summary>
    /// <typeparam name="TOrderLine"></typeparam>
    public abstract class PurchaseOrderWithLines<TOrderLine> : PurchaseOrder
        where TOrderLine : OrderLine
    {
        /// <summary>
        /// The lines for a subclassed <see cref="Order"/>
        /// </summary>
        public TOrderLine[] Lines { get; set; }
    }
}