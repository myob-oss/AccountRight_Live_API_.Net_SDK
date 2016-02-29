using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// A service that provides access to the <see cref="VersionInfo"/> resource
    /// </summary>
    public sealed class VersionInfoService : ServiceBase
    {
        /// <summary>
        /// Initialise a service that can retrieve <see cref="VersionInfo"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public VersionInfoService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Get the <see cref="VersionMap"/> information
        /// </summary>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void Get(ICompanyFileCredentials credentials, Action<HttpStatusCode, VersionInfo> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate(BuildUri(), credentials, onComplete, onError, null);
        }

        /// <summary>
        /// Get the <see cref="VersionMap"/> information
        /// </summary>
        /// <param name="credentials">The company file credentials</param>
        /// <returns></returns>
        public VersionInfo Get(ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<VersionInfo>(BuildUri(), credentials, null);
        }

#if ASYNC
        /// <summary>
        /// Get the <see cref="VersionMap"/> information
        /// </summary>
        /// <param name="credentials">The company file credentials</param>
        /// <returns></returns>
        public Task<VersionInfo> GetAsync(ICompanyFileCredentials credentials)
        {
            return this.GetAsync(credentials, CancellationToken.None);
        }

        /// <summary>
        /// Get the <see cref="VersionMap"/> information
        /// </summary>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<VersionInfo> GetAsync(ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiGetRequestAsync<VersionInfo>(this.BuildUri(), credentials, cancellationToken, null);
        }
#endif

        private Uri BuildUri()
        {
            return new Uri(string.Format("{0}/info", Configuration.ApiBaseUrl));
        }
    }
}