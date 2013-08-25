using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK
{
    public interface IOAuthKeyService
    {
        /// <summary>
        /// The oauth tokens
        /// </summary>
        OAuthTokens OAuthResponse { get; set; }
    }
}