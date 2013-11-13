using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Item
    /// </summary>
    public class Item : BaseEntity
    {
        /// <summary>
        /// Item number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <para>True indicates the item is active.</para>
        /// <para>False indicates the item is inactive.</para>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// A description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// <para>True indicates to use the description text instead of item name on sale invoices and purchase orders.</para>
        /// <para>False indicates not to use the item description on sales and purchases.</para>
        /// </summary>
        public bool UseDescription { get; set; }

        /// <summary>
        /// Item custom list1
        /// </summary>
        public Identifier CustomList1 { get; set; }

        /// <summary>
        /// Item custom list2
        /// </summary>
        public Identifier CustomList2 { get; set; }

        /// <summary>
        /// Item custom list3
        /// </summary>
        public Identifier CustomList3 { get; set; }

        /// <summary>
        /// Item custom field1
        /// </summary>
        public Identifier CustomField1 { get; set; }

        /// <summary>
        /// Item custom field2
        /// </summary>
        public Identifier CustomField2 { get; set; }

        /// <summary>
        /// Item custom field3
        /// </summary>
        public Identifier CustomField3 { get; set; }

        /// <summary>
        /// Quantity of units held in inventory
        /// </summary>
        public double QuantityOnHand { get; set; }

        /// <summary>
        /// Quantity of the item held in pending sale invoices.
        /// </summary>
        public decimal QuantityCommitted { get; set; }

        /// <summary>
        /// Quantity of the item held in pending purchase orders.
        /// </summary>
        public decimal QuantityOnOrder { get; set; }

        /// <summary>
        /// Calculated quantity of the item available for sale.
        /// </summary>
        public decimal QuantityAvailable { get; set; }

        /// <summary>
        /// Item's average cost when the quantity on hand is equal to or greater than zero.
        /// </summary>
        public decimal? AverageCost { get; set; }

        /// <summary>
        /// Dollar value of units held in inventory.
        /// </summary>
        public decimal CurrentValue { get; set; }

        /// <summary>
        /// Item's base selling price.
        /// </summary>
        public decimal BaseSellingPrice { get; set; }

        /// <summary>
        /// Uniform resource identifier to retrieve the Item's photo
        /// </summary>
        public Uri PhotoURI { get; set; }
    }
}