using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    public sealed class AccountingPropertiesService : ReadableService<AccountingProperties>
    {
        public override string Route
        {
            get { return "GeneralLedger/AccountingProperties"; }
        }

        public AccountingPropertiesService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override AccountingProperties Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return base.GetRange(cf, null, credentials).Items.Maybe(_ => _[0]);
        }

        public override void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, AccountingProperties> onComplete, Action<Uri, Exception> onError)
        {
            base.GetRange(cf, null, credentials, (code, collection) => onComplete(code, collection.Items.Maybe(_ => _[0])), onError);
        }
    }
}
