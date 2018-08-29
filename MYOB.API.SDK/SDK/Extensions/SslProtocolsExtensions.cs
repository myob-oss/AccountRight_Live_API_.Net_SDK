#if !PORTABLE
namespace System.Security.Authentication
{
    /// <summary>
    /// Ssl protocol extensions
    /// </summary>
    public static class SslProtocolsExtensions
    {
        /// <summary>
        /// Bit flag for Tls 1.2
        /// </summary>
        public const SslProtocols Tls12 = (SslProtocols)0x00000C00;
        /// <summary>
        /// Bit flag for Tls 1.1
        /// </summary>
        public const SslProtocols Tls11 = (SslProtocols)0x00000300;
    }
}
#endif
