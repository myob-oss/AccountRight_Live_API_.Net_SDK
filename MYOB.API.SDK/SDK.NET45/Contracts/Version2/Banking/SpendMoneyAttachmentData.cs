#if NET35
#else
#if NET40
#else
namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// Describes the AttachmentData object
    /// </summary>
    public class SpendMoneyAttachmentData : BaseEntity
    {
        /// <summary>
        /// Name of the Attachment. IE: bill.pdf
        /// </summary>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// <para>Only used in the response</para>
        /// </summary>
        public string ThumbnailUri { get; set; }

        /// <summary>
        /// <para>Only used in the response</para>
        /// </summary>
        public string FileUri { get; set; }

        /// <summary>
        /// Base64 string of the File being uploaded
        /// </summary>
        public string FileBase64Content { get; set; }
    }
}
#endif
#endif