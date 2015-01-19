using System;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts;
#if ASYNC
using System.Threading;
using System.Threading.Tasks;
#endif

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    /// <summary>
    /// A service that provides access to the <see cref="LinkedAccount"/> resource
    /// </summary>
    public sealed class LinkedAccountService : MutableService<LinkedAccount>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="LinkedAccount"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public LinkedAccountService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "GeneralLedger/LinkedAccount"; }
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        public override void Delete(Contracts.CompanyFile cf, System.Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Delete(Contracts.CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

#if ASYNC
        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="uid"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }
        
#endif

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override string Insert(Contracts.CompanyFile cf, LinkedAccount entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="errorLevel"></param>
        public override void Insert(Contracts.CompanyFile cf, LinkedAccount entity, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode, string> onComplete, Action<Uri, Exception> onError, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }

#if ASYNC
        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="entity"></param>
        /// <param name="credentials"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public override Task<string> InsertAsync(CompanyFile cf, LinkedAccount entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
        {
            throw new NotSupportedException();
        }
#endif    
    }
}
