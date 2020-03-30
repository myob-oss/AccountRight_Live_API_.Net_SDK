using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describes an item purchase order
    /// </summary>
    public class ItemPurchaseOrder : PurchaseOrderWithMultiCurrencySupport<ItemPurchaseOrderLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public ItemPurchaseOrder()
        {
            OrderDeliveryStatus = DocumentAction.Print;
        }

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
        public DocumentAction OrderDeliveryStatus { get; set; }
    }
}
