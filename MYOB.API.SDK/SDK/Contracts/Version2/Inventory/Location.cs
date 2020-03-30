using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

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
            IsActive = true;
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
        /// Notes describing the Location.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// <para>True indicates the location is Active. (default)</para>
        /// <para>False indicates the location is not Active.</para>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// <para>True indicates the location can be used to Sell Items from. (default)</para>
        /// <para>False indicates the location cannot be.</para>
        /// </summary>
        public bool CanSell { get; set; }

        /// <summary>
        /// Address of the Location
        /// </summary>
        public Address Address { get; set; }
    }
}