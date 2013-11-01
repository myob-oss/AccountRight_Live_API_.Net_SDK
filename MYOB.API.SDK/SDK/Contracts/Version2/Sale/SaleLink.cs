namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Link to the Sale resource
    /// </summary>
    public class SaleLink : BaseLink
    {
        /// <summary>
        /// The number of the invoice or order
        /// </summary>
        public string Number { get; set; }
    }
}