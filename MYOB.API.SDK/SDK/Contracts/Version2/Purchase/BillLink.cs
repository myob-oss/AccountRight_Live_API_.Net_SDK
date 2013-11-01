namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the Link to the Purchase/Bill resource
    /// </summary>
    public class BillLink : BaseLink
    {
        /// <summary>
        /// The number of the bill
        /// </summary>
        public string Number { get; set; }
    }
}