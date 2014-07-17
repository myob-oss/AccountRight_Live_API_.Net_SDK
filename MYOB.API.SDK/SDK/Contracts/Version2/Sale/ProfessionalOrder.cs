using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a service order
    /// </summary>
    public class ProfessionalOrder : OrderWithLines<ProfessionalOrderLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public ProfessionalOrder()
        {
            DeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// Sale order comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// The promised date
        /// </summary>
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Invoice delivery status assigned.
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }
    }
}