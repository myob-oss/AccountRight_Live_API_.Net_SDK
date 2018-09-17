using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// Describes an Error
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class Error
    {
        /// <summary>
        /// The name of the error
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A message describing the error
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Some extra details
        /// </summary>
        public string AdditionalDetails { get; set; }

        /// <summary>
        /// An error code
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// The severity
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// The learn more link
        /// </summary>
        public string LearnMore { get; set; }
    }
}
