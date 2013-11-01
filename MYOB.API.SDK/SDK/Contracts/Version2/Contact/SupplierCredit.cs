namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the supplier credit
    /// </summary>
    public class SupplierCredit
    {
        /// <summary>
        /// The suppliers credit limit
        /// </summary>
        public decimal Limit { get; set; }

        /// <summary>
        /// The avilable credit limit
        /// </summary>
        public decimal Available { get; set; }

        /// <summary>
        /// The past due balance
        /// </summary>
        public decimal PastDue { get; set; }
    }
}