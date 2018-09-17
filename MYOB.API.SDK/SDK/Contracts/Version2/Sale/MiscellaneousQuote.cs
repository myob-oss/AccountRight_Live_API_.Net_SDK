using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a service order
    /// </summary>
    public class MiscellaneousQuote : QuoteWithLines<MiscellaneousQuoteLine>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public MiscellaneousQuote()
        {
            DeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// The promised date
        /// </summary>
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Invoice delivery status assigned.
        /// </summary>
        public DocumentAction DeliveryStatus { get; set; }
    }
}