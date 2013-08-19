using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Item
    /// </summary>
    public class Item : BaseEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public bool UseDescription { get; set; }
        public Identifier CustomList1 { get; set; }
        public Identifier CustomList2 { get; set; }
        public Identifier CustomList3 { get; set; }
        public Identifier CustomField1 { get; set; }
        public Identifier CustomField2 { get; set; }
        public Identifier CustomField3 { get; set; }
        public double QuantityOnHand { get; set; }
        public decimal QuantityCommitted { get; set; }
        public decimal QuantityOnOrder { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal? AverageCost { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal BaseSellingPrice { get; set; }
        public Uri PhotoURI { get; set; }
    }
}