using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK
{
    public interface IApiRequestHandlerFactory
    {
        IApiRequestHandler GetApiRequestHandler(IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null);
    }
}