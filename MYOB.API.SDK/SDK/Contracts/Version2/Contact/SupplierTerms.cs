namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes additional terms for a supplier
    /// </summary>
    public class SupplierTerms : Terms
    {
        /// <summary>
        /// % Volume discount.
        /// </summary>
        public double VolumeDiscount { get; set; }
    }
}