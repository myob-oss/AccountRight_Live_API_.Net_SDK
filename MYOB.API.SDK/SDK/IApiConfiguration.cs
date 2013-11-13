namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// An interface for the API configuration
    /// </summary>
    public interface IApiConfiguration
    {
        /// <summary>
        /// The clientId
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// The clientSecret
        /// </summary>
        string ClientSecret { get; }

        /// <summary>
        /// The application redirectUrl, for desktop this is normally set to 'http://desktop'
        /// </summary>
        string RedirectUrl { get; }

        /// <summary>
        /// The api base url, for network mode this may be something like http://localhost:8080/accountright
        /// </summary>
        string ApiBaseUrl { get; }
    }
}