using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK
{
    public class SimpleOAuthKeyService : IOAuthKeyService
    {
        public OAuthTokens OAuthResponse { get; set; }
    }
}