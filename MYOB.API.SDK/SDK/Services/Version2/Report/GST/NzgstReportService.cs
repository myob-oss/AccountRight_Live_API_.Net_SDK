using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2.Report.GST;

namespace MYOB.AccountRight.SDK.Services.Report.GST
{
    /// <summary>
    /// A service that provide access to the <see cref="NZGSTReport"/> resource.
    /// </summary>
    public sealed class NZGSTReportService : GetOnlyService<NZGSTReport>
    {
        /// <summary>
        /// Initialise a service that can fetch <see cref="NZGSTReport"/> information
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public NZGSTReportService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Report/GST/NZGSTReport"; }
        }
    }
}
