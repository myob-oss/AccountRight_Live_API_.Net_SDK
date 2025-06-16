using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Communication
{
    public class ApiRequestHandlerFactory : IApiRequestHandlerFactory
    {
        public IApiRequestHandler GetApiRequestHandler(IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null)
        {
            return new ApiRequestHandler(configuration, credentials, oauth);
        }
    }
}