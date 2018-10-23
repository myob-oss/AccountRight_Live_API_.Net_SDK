namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes a link to an <see cref="Contact"/> resource
    /// </summary>
    public class ContactLink : CardLink
    {
        /// <summary>
        /// The type of the contact
        /// </summary>
        public ContactType Type { get; set; }
    }
}
