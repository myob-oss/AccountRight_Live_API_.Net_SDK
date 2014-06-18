namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Link to the Sale/Order resource
    /// </summary>
    public class SaleOrderLink : BaseLink
    {
        /// <summary>
        /// The number of the order
        /// </summary>
        public string Number { get; set; }
    }

}