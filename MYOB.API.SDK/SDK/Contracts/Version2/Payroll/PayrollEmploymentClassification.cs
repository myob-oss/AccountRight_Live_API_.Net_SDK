namespace MYOB.AccountRight.SDK.Contracts.Version2.Payroll
{
    using System;

    /// <summary>
    /// Employment classification
    /// </summary>
    public class PayrollEmploymentClassification
    {
        /// <summary>
        /// Unique id of the employment classification
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Rowversion
        /// </summary>
        public string Rowversion { get; set; }

        /// <summary>
        /// URI
        /// </summary>
        public Uri URI { get; set; }
    }
}
