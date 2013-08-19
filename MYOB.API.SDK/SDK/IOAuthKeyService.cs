using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK
{
    public interface IOAuthKeyService
    {
        OAuthTokens OAuthResponse { get; set; }
    }
}