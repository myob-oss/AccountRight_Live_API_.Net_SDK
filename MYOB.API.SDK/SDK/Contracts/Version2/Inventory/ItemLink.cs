namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Describes a link to the <see cref="Item"/> resource
    /// </summary>
    public class ItemLink : BaseLink
    {
        /// <summary>
        /// Item number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; set; }
    }
}