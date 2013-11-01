using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// Interface for classes that will store and retrieve OAuthTokens
    /// </summary>
    public interface IOAuthKeyService
    {
        /// <summary>
        /// The OAuth tokens
        /// </summary>
        OAuthTokens OAuthResponse { get; set; }
    }
}