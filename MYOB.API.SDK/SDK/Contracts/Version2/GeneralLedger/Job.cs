using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes a Job resource
    /// </summary>
    public class Job : BaseEntity
    {
        /// <summary>
        /// Number assigned to the job.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Indicates the job is a header.
        /// </summary>
        public bool? IsHeader { get; set; }

        /// <summary>
        /// Name assigned to the job.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description text for the job.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A link to the parent <see cref="Job"/> resource
        /// </summary>
        public JobLink ParentJob { get; set; }

        /// <summary>
        /// A link to a related customer resource
        /// </summary>
        public CardLink LinkedCustomer { get; set; }

        /// <summary>
        /// % of the job completed.
        /// </summary>
        public decimal PercentComplete { get; set; }

        /// <summary>
        /// The job start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The job completion date
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// The job contact
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// The job manager
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// Indicates the job is active.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Indicates if a job is used to track reimbursable expenses.
        /// </summary>
        public bool? TrackReimbursables { get; set; }
    }
}