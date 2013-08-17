namespace MYOB.AccountRight.SDK
{
    public interface IApiConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string RedirectUrl { get; }
        string ApiBaseUrl { get; }
    }
}