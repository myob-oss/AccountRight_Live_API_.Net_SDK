using System;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    public sealed class CategoryRegisterService : ReadableService<CategoryRegister>
    {
        public CategoryRegisterService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "GeneralLedger/CategoryRegister"; }
        }

        public override CategoryRegister Get(Contracts.CompanyFile cf, System.Guid uid, ICompanyFileCredentials credentials)
        {
            throw new NotSupportedException();
        }

        public override void Get(Contracts.CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode, CategoryRegister> onComplete, Action<Uri, Exception> onError)
        {
            throw new NotSupportedException();
        }

        public override CategoryRegister Get(Contracts.CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
        {
            throw new NotSupportedException();
        }

        public override void Get(Contracts.CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode, CategoryRegister> onComplete, Action<Uri, Exception> onError)
        {
            throw new NotSupportedException();
        }

#if ASYNC
        public override Task<CategoryRegister> GetAsync(Contracts.CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return Task.Factory.StartNew<CategoryRegister>(() => { throw new NotSupportedException(); });      
        }

        public override Task<CategoryRegister> GetAsync(Contracts.CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
        {
            return Task.Factory.StartNew<CategoryRegister>(() => { throw new NotSupportedException(); }); 
        }
#endif
    }
}