namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Quote Status Type
    /// </summary>
    public enum SaleQuoteStatus
    {
        /// <summary>
        /// Open <see cref="Quote"/>
        /// </summary>
        Open = 0,
        /// <summary>
        /// Accepted <see cref="Quote"/>
        /// </summary>
        Accepted = 1,
        /// <summary>
        /// Declined <see cref="Quote"/>
        /// </summary>
        Declined = 2,
        /// <summary>
        /// Invoiced <see cref="Quote"/>
        /// </summary>
        Invoiced = 3
    }
}
