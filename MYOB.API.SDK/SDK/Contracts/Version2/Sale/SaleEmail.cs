using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a basic sale email
    /// </summary>
    public class SaleEmail
    {
        /// <summary>
        /// The resource type, e.g Invoice or Quote
        /// </summary>
        public string ResourceType { get; set;}

        /// <summary>
        /// The layout type, e.g Service or Item
        /// </summary>
        public string LayoutType { get; set; }

        /// <summary>
        /// The uid of the resource, e.g Quote UID or Invoice UID
        /// </summary>
        public Guid EntityUid { get; set; }

        /// <summary>
        /// The form template for printing the resource
        /// </summary>
        public string FormTemplate { get; set; }

        /// <summary>
        /// The list of recipients to send the email to
        /// </summary>
        public List<EmailContact> To { get; set; }

        /// <summary>
        /// The email sender
        /// </summary>
        public EmailContact From { get; set; }

        /// <summary>
        /// The email subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The email message
        /// </summary>
        public string Message { get; set; }

    }

    /// <summary>
    /// Describes an email address
    /// </summary>
    public class EmailContact
    {
        /// <summary>
        /// The display name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address
        /// </summary>
        public string Email { get; set; }
    }

}
