using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// A simple OAuth key service (memory only)
    /// </summary>
    /// <remarks>
    /// See samples for implementations that use other storage mechanisms e.g. IsolatedStorage
    /// </remarks>
    public class SimpleOAuthKeyService : IOAuthKeyService
    {
        /// <summary>
        /// The OAuth tokens
        /// </summary>
        public OAuthTokens OAuthResponse { get; set; }
    }
}