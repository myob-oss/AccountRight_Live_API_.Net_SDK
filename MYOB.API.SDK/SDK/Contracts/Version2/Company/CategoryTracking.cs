namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Described the available Category Trancking options where applicable
    /// </summary>
    public enum CategoryTracking
    {
        /// <summary>
        /// No category tracking
        /// </summary>
        Off,

        /// <summary>
        /// Categories allowed but not required
        /// </summary>
        OnAndNotRequired,

        /// <summary>
        /// Categories requried
        /// </summary>
        OnAndRequired
    }
}
