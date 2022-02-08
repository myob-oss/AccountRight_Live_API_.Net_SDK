using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Custom List
    /// </summary>
    public class CustomList
    {
        /// <summary>
        /// Record Id
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// CustomList is System 
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// List Index
        /// </summary>
        public int ListIndex { get; set; }

        /// <summary>
        /// List Name
        /// </summary>
        public string ListName { get; set; }

        /// <summary>
        /// List Type
        /// </summary>
        public CustomListsType ListType { get; set; }

        /// <summary>
        /// List Index
        /// </summary>
        public IEnumerable<CustomListValue> Values { get; set; }


    }

    /// <summary>
    /// Represents the type of custom list.
    /// </summary>
    public enum CustomListsType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Item
        /// </summary>
        Item,
        /// <summary>
        /// Customer
        /// </summary>
        Customer,
        /// <summary>
        /// Supplier
        /// </summary>
        Supplier,
        /// <summary>
        /// Employee
        /// </summary>
        Employee,
        /// <summary>
        /// Personal
        /// </summary>
        Personal
    }
}
