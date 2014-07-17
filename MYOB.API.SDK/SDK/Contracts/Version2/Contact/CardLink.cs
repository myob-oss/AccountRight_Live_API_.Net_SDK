namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes a link to a <see cref="Contact"/> resource
    /// </summary>
    public class CardLink : BaseLink
    {
        /// <summary>
        /// The name of the contact resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact Identifier    
        /// </summary>
        public string DisplayID { get; set; }
    }
}