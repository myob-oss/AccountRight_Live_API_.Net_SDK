using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// Base class for resources that support a photo resource that can be updated
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MutablePhotoService<T> : MutableService<T>, IMutablePhoto<T> where T : BaseEntity
    {
        /// <summary>
        /// Initialise base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        protected MutablePhotoService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService)
            : base(configuration, webRequestFactory, keyService)
        {

        }

        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, byte[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate<Photo>(BuildUri(cf, uid, "/Photo"), credentials, (code, photo) => onComplete(code, photo.Maybe(_ => _.Data)), onError, null);
        }

        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual byte[] GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<Photo>(BuildUri(cf, uid, "/Photo"), credentials, null).Maybe(_ => _.Data);
        }

#if ASYNC
        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual Task<byte[]> GetPhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return this.GetPhotoAsync(cf, uid, credentials, CancellationToken.None);
        } 

        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async virtual Task<byte[]> GetPhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            var res = await this.MakeApiGetRequestAsync<Photo>(this.BuildUri(cf, uid, "/Photo"), credentials, cancellationToken, null);
            return res.Maybe(_ => _.Data);
        } 
#endif

        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiDeleteRequestDelegate(BuildUri(cf, uid, "/Photo"), credentials, onComplete, onError);
        }

        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        public virtual void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            MakeApiDeleteRequestSync(BuildUri(cf, uid, "/Photo"), credentials);
        }

#if ASYNC
        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        public Task DeletePhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return this.DeletePhotoAsync(cf, uid, credentials, CancellationToken.None);
        } 

        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        public Task DeletePhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiDeleteRequestAsync(this.BuildUri(cf, uid, "/Photo"), credentials, cancellationToken);
        } 
#endif

        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        public virtual void SavePhoto(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiPutRequestDelegate(BuildUri(cf, uid, "/Photo"), new Photo { Data = photoData }, credentials, onComplete, onError);
        }

        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public virtual string SavePhoto(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials)
        {
            return MakeApiPutRequestSync(BuildUri(cf, uid, "/Photo"), new Photo { Data = photoData }, credentials);
        }

#if ASYNC
        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        public Task<string> SavePhotoAsync(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials)
        {
            return this.SavePhotoAsync(cf, uid, photoData, credentials, CancellationToken.None);
        } 

        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> SavePhotoAsync(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            return this.MakeApiPutRequestAsync(this.BuildUri(cf, uid, "/Photo"), new Photo() { Data = photoData }, credentials, cancellationToken);
        } 
#endif
    }
}