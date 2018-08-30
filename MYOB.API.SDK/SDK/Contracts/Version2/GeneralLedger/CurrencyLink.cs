namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// A reference to a related <see cref="Currency"/> entity
    /// </summary>
    public class CurrencyLink : BaseLink
    {
        /// <summary>
        /// The code assigned
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The name of the currency
        /// </summary>
        public string Name { get; set; }
    }
}