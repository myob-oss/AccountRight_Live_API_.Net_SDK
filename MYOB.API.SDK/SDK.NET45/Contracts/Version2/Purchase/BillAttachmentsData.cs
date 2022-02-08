using System;
using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describes the outer Array holding  BillAttachmentData
    /// </summary>
    public class BillAttachmentsData : BaseEntity
    {
        /// <summary>
        /// Array of BillAttachment Objects
        /// </summary>
        public List<BillAttachmentData> Attachments;

        /// <summary>
        /// Only used in SDK - UID of the Bill
        /// </summary>
        public Guid BillUID;

        /// <summary>
        /// Only used in SDK - Layout of intended Bill
        /// </summary>
        public string BillLayout;
    }
}
