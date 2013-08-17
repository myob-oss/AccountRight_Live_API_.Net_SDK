using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    public class Job : BaseEntity
    {
        public string Number { get; set; }

        public bool? IsHeader { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public JobLink ParentJob { get; set; }

        public CardLink LinkedCustomer { get; set; }

        public decimal PercentComplete { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public string Contact { get; set; }

        public string Manager { get; set; }

        public bool? IsActive { get; set; }

        public bool? TrackReimbursables { get; set; }
    }
}