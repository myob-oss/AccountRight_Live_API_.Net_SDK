using MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes a link to a <see cref="Activity"/> resource
    /// </summary>
    public class ActivityLink : BaseLink
    {
        /// <summary>
        /// The name of the Activity resource
        /// </summary>
        public string Name { get; set; }
    }
}