using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// InventoryAdjustment
    /// </summary>
    public class InventoryAdjustment : BaseEntity
    {
        /// <summary>
        /// The inventory journal number
        /// </summary>
        public string InventoryJournalNumber { get; set; }

        /// <summary>
        /// The date for the adjustment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Is this a year end adjustment (period 13)
        /// </summary>
        public bool IsYearEndAdjustment { get; set; }

        /// <summary>
        /// A description of the adjustment
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The adjustment entries
        /// </summary>
        public IEnumerable<InventoryAdjustmentLine> Lines { get; set; }

        /// <summary>
        /// The related category
        /// </summary>
        public CategoryLink Category { get; set; }
    }

    /// <summary>
    /// An entry adjustment
    /// </summary>
    public class InventoryAdjustmentLine 
    {
        /// <summary>
        /// The row id (required to update an existing entry)
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// The adjustment quantity (defaults to 0)
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// The unit cost of the item, defaults to average cost if not supplied
        /// </summary>
        public decimal? UnitCost { get; set; }

        /// <summary>
        /// The amount for the line (<see cref="Quantity"/>/<see cref="UnitCost"/>)
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// The item being adjusted (required)
        /// </summary>
        public ItemLink Item { get; set; }

        /// <summary>
        /// The account affected (required if calculated <see cref="Amount"/> > 0)
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The related Job (optional)
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// A description of the line adjustment
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time.
        /// <para>ONLY required for updating an existing sale line.</para>
        /// <para>NOT required when creating a new sale invoice.</para>
        /// </summary>
        public string RowVersion { get; set; }
    }
}