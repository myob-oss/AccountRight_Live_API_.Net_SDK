namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes a linked account resource
    /// </summary>
    public class LinkedAccount : BaseEntity
    {
        /// <summary>
        /// A link to the <see cref="Account"/> resource
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// Linked account classification.
        /// </summary>
        public string Description { get; set; }
    }
}