using System;

namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// The AccountRight product level that the company file supports
    /// </summary>
    public enum ProductLevelType
    {
        /// <summary>
        /// Basic
        /// </summary>
        Basic = 10,

        /// <summary>
        /// Standard
        /// </summary>
        Standard = 20,

        /// <summary>
        /// Plus
        /// </summary>
        Plus = 30,

        /// <summary>
        /// Premier
        /// </summary>
        Premier = 50,
    }


    /// <summary>
    /// Describes the company file supported product  level
    /// </summary>
    public class ProductLevel
    {
        /// <summary>
        /// Integer Code for AccountRight product level
        /// </summary>
        public int Code { get; set; }
        
        /// <summary>
        /// Common Name of AccountRight product level
        /// </summary>
        public ProductLevelType Name
        {
            get
            {
                var level = (ProductLevelType) Enum.ToObject(typeof(ProductLevelType), Code);
                return level;
            }
			set {}
        }
    }
}
