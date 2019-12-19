using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a service order
    /// </summary>
    public class ServiceOrder : OrderWithMultiCurrencySupport<ServiceOrderLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public ServiceOrder()
        {
            DeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// Ship to address text.
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
        /// Invoice delivery status assigned.
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }
    }
}