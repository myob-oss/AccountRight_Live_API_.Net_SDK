using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public abstract class MutableService<T> : ReadableService<T>, IMutable<T> where T : BaseEntity
    {
        protected MutableService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public virtual void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            MakeApiDeleteRequestSync(BuildUri(cf, uid), credentials);
        }

#if ASYNC
        public virtual Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiDeleteRequestAsync(BuildUri(cf, uid), credentials);
        }
#endif

        public virtual void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiDeleteRequestDelegate(BuildUri(cf, uid), credentials, onComplete, onError);
        }

        public virtual string Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials)
        {
            return MakeApiPutRequestSync(BuildUri(cf, entity.UID), entity, credentials);
        }

#if ASYNC
        public virtual Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials)
        {
            return MakeApiPutRequestAsync(BuildUri(cf, entity.UID), entity, credentials);
        }
#endif

        public virtual void Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiPutRequestDelegate(BuildUri(cf, entity.UID), entity, credentials, onComplete, onError);
        }

        public virtual string Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials)
        {
            return MakeApiPostRequestSync(BuildUri(cf), entity, credentials);
        }

        public virtual void Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiPostRequestDelegate(BuildUri(cf), entity, credentials, onComplete, onError);
        }

#if ASYNC
        public virtual Task<string> InsertAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials)
        {
            return MakeApiPostRequestAsync(BuildUri(cf), entity, credentials);
        }
#endif
    }
}