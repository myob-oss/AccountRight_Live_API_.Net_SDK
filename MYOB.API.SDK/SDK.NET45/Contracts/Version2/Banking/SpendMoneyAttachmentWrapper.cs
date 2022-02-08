using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// Describes the Spend Money AttachmentsData container object
    /// </summary>
    public class SpendMoneyAttachmentWrapper : BaseEntity
    {
        /// <summary>
        /// Array of Attachment Objects
        /// </summary>
        public List<SpendMoneyAttachmentData> Attachments;
    }
}
