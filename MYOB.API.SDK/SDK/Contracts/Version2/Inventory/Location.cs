namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Item
    /// </summary>
    public class Location : BaseEntity
    {
        /// <summary>
        /// Initialise an Item entity
        /// </summary>
        public Location()
        {
            IsVisible = true;
        }

        /// <summary>
        /// Location notes.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Name of the location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <para>True indicates the location is Visible. (default)</para>
        /// <para>False indicates the location is not Visible.</para>
        /// </summary>
        public bool IsVisible { get; set; }
    }
}