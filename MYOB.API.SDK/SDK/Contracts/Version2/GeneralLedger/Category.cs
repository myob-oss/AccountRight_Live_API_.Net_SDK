namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes a Category resource
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Initialises an instance of the Category class
        /// </summary>
        public Category()
        {
            IsActive = true;
        }

        /// <summary>
        /// Display id assigned
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// Name assigned
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description text for the category.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates the category is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}