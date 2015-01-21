using System;
using System.Runtime.Serialization;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Describes a Paged Set of returned data
    /// </summary>
    /// <typeparam name="T">The type of entities that have been returned</typeparam>
    /// <remarks>
    /// If the NextPageLink is populated there is more data available to be retrieved.
    /// </remarks>
    public class PagedCollection<T> : IETag
    {
        /// <summary>
        /// The retrieved items
        /// </summary>
        public T[] Items { get; set; }

        /// <summary>
        /// The link to the next set of items that match the requested criteria
        /// </summary>
        public Uri NextPageLink { get; set; }

        /// <summary>
        /// The number of items that can be retrieved
        /// </summary>
        public long? Count { get; set; }

        /// <summary>
        /// Returns the ETag from the HTTP response header
        /// </summary>
        public string ETag { get; set; }
    }
}