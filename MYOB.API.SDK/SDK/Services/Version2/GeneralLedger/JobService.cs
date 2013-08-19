using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    public sealed class JobService : MutableService<Job>
    {
        public JobService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        public override string Route
        {
            get { return "GeneralLedger/Job"; }
        }
    }
}