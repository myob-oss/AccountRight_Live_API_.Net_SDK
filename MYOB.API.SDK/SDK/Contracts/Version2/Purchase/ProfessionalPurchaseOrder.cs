using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describes a professional order
    /// </summary>
    public class ProfessionalPurchaseOrder : PurchaseOrderWithLines<ProfessionalPurchaseOrderLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public ProfessionalPurchaseOrder()
        {
            OrderDeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// Order comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// The promised date
        /// </summary>
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Invoice delivery status assigned.
        /// </summary>
        public DocumentAction OrderDeliveryStatus { get; set; }
    }
}