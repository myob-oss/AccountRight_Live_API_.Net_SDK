using System;
using System.Net;
using System.Threading.Tasks; 
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services.Contact
{
    public sealed class ContactService : ReadableService<Contracts.Version2.Contact.Contact>, IReadablePhoto<Contracts.Version2.Contact.Contact>
    {
        public ContactService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "Contact"; }
        }

        public void GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, byte[]> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestDelegate<Photo>(BuildUri(cf, uid, "/Photo"), credentials, (code, photo) => onComplete(code, photo.Maybe(_ => _.Data)), onError);
        }

        public byte[] GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<Photo>(BuildUri(cf, uid, "/Photo"), credentials).Maybe(_ => _.Data);
        }

		public Task<byte[]> GetPhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestAsync<Photo>(BuildUri(cf, uid, "/Photo"), credentials).ContinueWith(t => t.Result.Maybe(_ => _.Data));
        }

    }
}
