namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Price level detail
    /// </summary>
    public class PriceLevelDetail
    {
        /// <summary>
        /// Name of the Price Level
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the Price Level
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// row version number
        /// </summary>
        public string RowVersion { get; set; }
    }
}