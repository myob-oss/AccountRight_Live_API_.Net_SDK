﻿namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a basic quote line
    /// </summary>
    public abstract class QuoteLine
    {
        /// <summary>
        /// Sequence of the entry within the item sale set. 
        /// <para>ONLY required for updating an existing quote line.</para>
        /// <para>NOT required when creating a new quote.</para>
        /// </summary>
        public int RowID { get; set; }

        /// <summary>
        /// The type of quote line
        /// </summary>
        public QuoteLineType Type { get; set; }

        /// <summary>
        /// The line description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incrementing number that can be used for change control but does does not preserve a date or a time.
        /// <para>ONLY required for updating an existing line.</para>
        /// <para>NOT required when creating a new quote.</para>
        /// </summary>
        public string RowVersion { get; set; }
    }
}