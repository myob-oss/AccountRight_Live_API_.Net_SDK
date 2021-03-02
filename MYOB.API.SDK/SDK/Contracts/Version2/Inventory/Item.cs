using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// Item
    /// </summary>
    public class Item : BaseEntity
    {
        /// <summary>
        /// Initialise an Item entity
        /// </summary>
        public Item()
        {
            IsActive = true;
        }

        /// <summary>
        /// Item number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <para>True indicates the item is active. (default)</para>
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
        /// The item is bought
        /// </summary>
        public bool IsBought { get; set; }

        /// <summary>
        /// The item is sold
        /// </summary>
        public bool IsSold { get; set; }

        /// <summary>
        /// The item is inventoried
        /// </summary>
        public bool IsInventoried { get; set; }

        /// <summary>
        /// An account that is used when <see cref="IsBought"/> is true and <see cref="IsInventoried"/> is false
        /// </summary>
        public AccountLink ExpenseAccount { get; set; }

        /// <summary>
        /// An account that is used when <see cref="IsSold"/> is true and <see cref="IsInventoried"/> is true
        /// </summary>
        public AccountLink CostOfSalesAccount { get; set; }

        /// <summary>
        /// An account that is used when <see cref="IsSold"/> is true
        /// </summary>
        public AccountLink IncomeAccount { get; set; }

        /// <summary>
        /// An account that is used when <see cref="IsInventoried"/> is true
        /// </summary>
        public AccountLink AssetAccount { get; set; }

        /// <summary>
        /// The details when <see cref="IsBought"/> is true
        /// </summary>
        public ItemBuyingDetails BuyingDetails { get; set; }

        /// <summary>
        /// The detaisl when <see cref="IsSold"/> is true
        /// </summary>
        public ItemSellingDetails SellingDetails { get; set; }

        /// <summary>
        /// Uniform resource identifier to retrieve the Item's photo
        /// </summary>
        public Uri PhotoURI { get; set; }
        /// <summary>
        /// List of LocationDetails
        /// </summary> 
        public ItemLocationDetail[] LocationDetails { get; set; }
        /// <summary>
        /// Default Sell Location Link
        /// </summary> 
        public LocationLink DefaultSellLocation { get; set; }
        /// <summary>
        /// Default Receive Location Link
        /// </summary> 
        public LocationLink DefaultReceiveLocation { get; set; }
    }

    /// <summary>
    /// Item Location Details
    /// </summary> 
    public class ItemLocationDetail
    {
        /// <summary>
        /// Location Link
        /// </summary> 
        public LocationLink Location { get; set; }

        /// <summary>
        /// Quantity On Hand for location
        /// </summary> 
        public double QuantityOnHand { get; set; }
    }

    /// <summary>
    /// The details when <see cref="Item.IsBought"/> is true
    /// </summary>
    public class ItemBuyingDetails
    {
        /// <summary>
        /// The last purchase price (read-only)
        /// </summary>
        public decimal LastPurchasePrice { get; set; }

        /// <summary>
        /// The standard cost
        /// </summary>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// The standard cost
        /// </summary>
        public bool? StandardCostTaxInclusive { get; set; }

        /// <summary>
        /// The unit of measure when buying items
        /// </summary>
        public string BuyingUnitOfMeasure { get; set; }

        /// <summary>
        /// The number of items in a buying unit
        /// </summary>
        public double? ItemsPerBuyingUnit { get; set; }

        /// <summary>
        /// The tax code
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// The restocking information
        /// </summary>
        public RestockingInformation RestockingInformation { get; set; }
    }

    /// <summary>
    /// Describes the restocking information
    /// </summary>
    public class RestockingInformation
    {
        /// <summary>
        /// The minimum level to generate a restocking alert
        /// </summary>
        public double? MinimumLevelForRestockingAlert { get; set; }

        /// <summary>
        /// The main supplier of the item
        /// </summary>
        public SupplierLink Supplier { get; set; }

        /// <summary>
        /// The supplier's item number
        /// </summary>
        public string SupplierItemNumber { get; set; }

        /// <summary>
        /// The default number of items/units to but when re-ordering
        /// </summary>
        public double DefaultOrderQuantity { get; set; }
    }

    /// <summary>
    /// The details when <see cref="Item.IsSold"/> is true
    /// </summary>
    public class ItemSellingDetails
    {
        /// <summary>
        /// The base selling price
        /// </summary>
        public decimal BaseSellingPrice { get; set; }

        /// <summary>
        /// The unit of measure when selling items
        /// </summary>
        public string SellingUnitOfMeasure { get; set; }

        /// <summary>
        /// The number of items in a selling unit
        /// </summary>
        public double? ItemsPerSellingUnit { get; set; }

        /// <summary>
        /// The tax code to use when selling items
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Is tax inclusive of the price
        /// </summary>
        public bool IsTaxInclusive { get; set; }

        /// <summary>
        /// The  price value to use to calculate the Sales Tax (AU only)
        /// </summary>
        public CalculateSalesTaxOn? CalculateSalesTaxOn { get; set; }

        /// <summary>
        /// A link to the item's selling price matrix
        /// </summary>
        public Uri PriceMatrixURI { get; set; }
    }

    /// <summary>
    /// Which price value to use to calculate the Sales Tax
    /// </summary>
    public enum CalculateSalesTaxOn
    {
        /// <summary>
        /// The actual selling price
        /// </summary>
        ActualSellingPrice,

        /// <summary>
        /// The base selling price
        /// </summary>
        BaseSellingPrice,

        /// <summary>
        /// The Level A price
        /// </summary>
        LevelA,

        /// <summary>
        /// The Level B price
        /// </summary>
        LevelB,

        /// <summary>
        /// The Level C price
        /// </summary>
        LevelC,

        /// <summary>
        /// The Level D price
        /// </summary>
        LevelD,

        /// <summary>
        /// The Level E price
        /// </summary>
        LevelE,

        /// <summary>
        /// The Level F price
        /// </summary>
        LevelF,

    }

}