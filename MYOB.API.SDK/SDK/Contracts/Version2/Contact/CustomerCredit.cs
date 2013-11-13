namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the CustomerCredit
    /// </summary>
    public class CustomerCredit
    {
        /// <summary>
        /// The credit limit 
        /// </summary>
        public decimal Limit { get; set; }

        /// <summary>
        /// The available credit
        /// </summary>
        public decimal Available { get; set; }

        /// <summary>
        /// The past due balance
        /// </summary>
        public decimal PastDue { get; set; }

        /// <summary>
        /// Indicates if the customer is on credit hold
        /// </summary>
        public bool OnHold { get; set; }
    }
}