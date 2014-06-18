namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a basic orderline
    /// </summary>
    public abstract class OrderLine 
    {
        /// <summary>
        /// Sequence of the entry within the item sale set. 
        /// <para>ONLY required for updating an existing order line.</para>
        /// <para>NOT required when creating a new order.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// The type of order line
        /// </summary>
        public OrderLineType Type { get; set; }

        /// <summary>
        /// The line description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time.
        /// <para>ONLY required for updating an existing line.</para>
        /// <para>NOT required when creating a new order.</para>
        /// </summary>
        public string RowVersion { get; set; }
    }
}