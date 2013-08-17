namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// A reference to a related <see cref="Account"/> entity
    /// </summary>
    public class AccountLink : BaseLink
    {
        /// <summary>
        /// Name of the referenced account. (Read only)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The DisplayID of the referenced account. (Read only)
        /// </summary>
        public string DisplayID { get; set; }
    }
}