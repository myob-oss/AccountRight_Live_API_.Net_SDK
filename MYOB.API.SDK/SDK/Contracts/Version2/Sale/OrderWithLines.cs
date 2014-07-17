namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Descibes a subclassed <see cref="Order"/> that has lines
    /// </summary>
    /// <typeparam name="TOrderLine"></typeparam>
    public abstract class OrderWithLines<TOrderLine> : Order
        where TOrderLine : OrderLine
    {
        /// <summary>
        /// The lines for a subclassed <see cref="Order"/>
        /// </summary>
        public TOrderLine[] Lines { get; set; }
    }
}