using System;
using System.Net;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    public abstract class MutablePhotoService<T> : MutableService<T>, IMutablePhoto<T> where T : BaseEntity
    {
        protected MutablePhotoService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) : base(configuration, webRequestFactory, keyService)
        {
        }

        public virtual void GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, byte[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestAsync<Photo>(BuildUri(cf, uid, "/Photo"), credentials, (code, photo) => onComplete(code, photo.Maybe(_ => _.Data)), onError);
        }

        public virtual byte[] GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<Photo>(BuildUri(cf, uid, "/Photo"), credentials).Maybe(_ => _.Data);
        }

        public virtual void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiDeleteRequestAsync(BuildUri(cf, uid, "/Photo"), credentials, onComplete, onError);
        }

        public virtual void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            MakeApiDeleteRequestSync(BuildUri(cf, uid, "/Photo"), credentials);
        }

        public virtual void SavePhoto(CompanyFile cf, Guid uid, byte[] entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiPutRequestAsync(BuildUri(cf, uid, "/Photo"), new Photo() { Data = entity }, credentials, onComplete, onError);
        }

        public virtual string SavePhoto(CompanyFile cf, Guid uid, byte[] entity, ICompanyFileCredentials credentials)
        {
            return MakeApiPutRequestSync(BuildUri(cf, uid, "/Photo"), new Photo() {Data = entity}, credentials);
        }

    }
}