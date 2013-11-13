namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Link to the Sale/Invoice resource
    /// </summary>
    public class InvoiceLink : BaseLink
    {
        /// <summary>
        /// The number of the invoice
        /// </summary>
        public string Number { get; set; }
    }

}