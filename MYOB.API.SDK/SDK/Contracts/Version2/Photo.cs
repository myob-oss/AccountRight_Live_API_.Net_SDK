using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    public class Photo
    {
        public Uri URI { get; set; }
        public Byte[] Data { get; set; }
        public string MimeType { get; set; }
    }
}