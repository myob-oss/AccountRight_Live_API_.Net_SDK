using System;
using System.Runtime.Serialization;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    public class PagedCollection<T> 
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
        public int? Count { get; set; }
    }
}