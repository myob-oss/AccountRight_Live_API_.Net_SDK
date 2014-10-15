using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/Invoice/TimeBilling resource
    /// </summary>
    public class TimeBillingOrder : OrderWithLines<TimeBillingOrderLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public TimeBillingOrder()
        {
            DeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// Shipping method text.
        /// </summary>
        public string ShipToAddress { get; set; }

        /// <summary>
        /// Sale order comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Shipping method text.
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// The promised date
        /// </summary>
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Order delivery status assigned.
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }
    }
}