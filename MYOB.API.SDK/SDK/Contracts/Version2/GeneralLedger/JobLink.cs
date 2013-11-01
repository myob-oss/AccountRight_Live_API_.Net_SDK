namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// A reference to a related <see cref="Job"/> entity
    /// </summary>
    public class JobLink : BaseLink
    {
        /// <summary>
        /// Number assigned to the job.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Name assigned to the job.
        /// </summary>
        public string Name { get; set; }
    }
}