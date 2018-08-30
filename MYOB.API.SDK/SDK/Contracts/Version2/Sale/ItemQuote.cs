using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes an item quote
    /// </summary>
    public class ItemQuote : QuoteWithLines<ItemQuoteLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public ItemQuote()
        {
            DeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// Ship to address text.
        /// </summary>
        public string ShipToAddress { get; set; }

        /// <summary>
        /// Comment.
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