using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// Describes a service that provides an operation (non-restful) via a POST action
    /// </summary>
    /// <typeparam name="TReq"></typeparam>
    /// <typeparam name="TResp"></typeparam>
    public interface IOperation<in TReq, TResp>
    {
        /// <summary>
        /// Perform an operation and wait for the response
        /// </summary>
        /// <param name="cf">A company file</param>
        /// <param name="entity">The data to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <returns>The operation response</returns>
        TResp Execute(CompanyFile cf, TReq entity, ICompanyFileCredentials credentials);

        /// <summary>
        /// Perform an operation and receive the response via an action
        /// </summary>
        /// <param name="cf">A company file</param>
        /// <param name="entity">The data to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Execute(CompanyFile cf, TReq entity, ICompanyFileCredentials credentials,
                  Action<HttpStatusCode, string, TResp> onComplete,
                  Action<Uri, Exception> onError);

#if ASYNC
        /// <summary>
        /// Perform an asynchronous operation and await the response
        /// </summary>
        /// <param name="cf">A company file</param>
        /// <param name="entity">The data to send</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The operation response</returns>
        Task<TResp> ExecuteAsync(CompanyFile cf, TReq entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken);
#endif
    }
}