using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describes the outer Array holding  BillAttachmentData
    /// </summary>
    public class BillAttachmentWrapper : BaseEntity
    {
        /// <summary>
        /// Array of BillAttachment Objects
        /// </summary>
        public List<BillAttachmentData> Attachments;
    }
}
