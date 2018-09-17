#if !PORTABLE
namespace System.Net
{
    using System.Security.Authentication;
    /// <summary>
    /// Support for Tls 1.1+
    /// </summary>
    public static class SecurityProtocolTypeExtensions
    {
        /// <summary>
        /// Flag for Tls 1.2
        /// </summary>
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)SslProtocolsExtensions.Tls12;
        /// <summary>
        /// Flag for Tls 1.1 
        /// </summary>
        public const SecurityProtocolType Tls11 = (SecurityProtocolType)SslProtocolsExtensions.Tls11;
    }
} 
#endif
