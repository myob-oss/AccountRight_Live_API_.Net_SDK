using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Inventory
{
    /// <summary>
    /// InventoryBuild
    /// </summary>
    public class InventoryBuild : BaseEntity
    {
        /// <summary>
        /// The inventory journal number
        /// </summary>
        public string InventoryJournalNumber { get; set; }
        
        /// <summary>
        /// The date for the build transaction
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// A description of the build transaction
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The build transaction entries
        /// </summary>
        public IEnumerable<InventoryBuildLine> Lines { get; set; }

        /// <summary>
        /// The related category
        /// </summary>
        public CategoryLink Category { get; set; }
    }

    /// <summary>
    /// A build transaction entry
    /// </summary>
    public class InventoryBuildLine
    {
        /// <summary>
        /// The row id (required to update an existing entry)
        /// </summary>
        public int RowID { get; set; }
        

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time.
        /// <para>ONLY required for updating an existing line.</para>
        /// <para>NOT required when creating a new line.</para>
        /// </summary>
        public string RowVersion { get; set; }
        
        /// <summary>
        /// The quantity of build transaction line (defaults to 0)
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// The unit cost of the item
        /// </summary>
        public decimal? UnitCost { get; set; }

        /// <summary>
        /// The amount for the build transaction line (<see cref="Quantity"/>/<see cref="UnitCost"/>) 
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// The item being built (required)
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
        /// A description of the build transaction line 
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Location of the build transaction line 
        /// </summary>
        public LocationLink Location { get; set; }
    }
}