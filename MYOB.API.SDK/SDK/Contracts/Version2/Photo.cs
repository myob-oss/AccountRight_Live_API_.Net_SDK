using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Describes a photo resource
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// The location where this entity can be retrieved. (Read only)
        /// </summary>
        public Uri URI { get; set; }

        /// <summary>
        /// The binary data of the photo
        /// </summary>
        public Byte[] Data { get; set; }

        /// <summary>
        /// The mime type of the image e.g. image/png
        /// </summary>
        public string MimeType { get; set; }
    }
}