namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// A reference to a related <see cref="Category"/> entity
    /// </summary>
    public class CategoryLink : BaseLink
    {
        /// <summary>
        /// The display id assigned
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// The name of the category
        /// </summary>
        public string Name { get; set; }
    }
}