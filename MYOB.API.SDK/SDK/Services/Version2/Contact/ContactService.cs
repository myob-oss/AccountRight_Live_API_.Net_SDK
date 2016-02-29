using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services.Contact
{
    using System.Threading;

    /// <summary>
    /// A service that provides access to the <see cref="Contact"/> resource
    /// </summary>
    public sealed class ContactService : ReadableService<Contracts.Version2.Contact.Contact>, IReadablePhoto<Contracts.Version2.Contact.Contact>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="Contact"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public ContactService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Contact"; }
        }

        /// <summary>
        /// Get the photo of a <see cref="Contact"/> resource
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public void GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, byte[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate<Photo>(BuildUri(cf, uid, "/Photo"), credentials, (code, photo) => onComplete(code, photo.Maybe(_ => _.Data)), onError, null);
        }

        /// <summary>
        /// Get the photo of a <see cref="Contact"/> resource
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public byte[] GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<Photo>(BuildUri(cf, uid, "/Photo"), credentials, null).Maybe(_ => _.Data);
        }

#if ASYNC
        /// <summary>
        /// Get the photo of a <see cref="Contact"/> resource
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<byte[]> GetPhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return this.GetPhotoAsync(cf, uid, credentials, CancellationToken.None);
        }

        /// <summary>
        /// Get the photo of a <see cref="Contact"/> resource
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<byte[]> GetPhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            var res = await this.MakeApiGetRequestAsync<Photo>(this.BuildUri(cf, uid, "/Photo"), credentials, cancellationToken, null);
            
            return res.Maybe(_ => _.Data);
        }
#endif
    }
}
