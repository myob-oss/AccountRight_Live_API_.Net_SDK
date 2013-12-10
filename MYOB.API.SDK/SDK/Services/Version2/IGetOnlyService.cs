using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    using System.Threading;

    /// <summary>
    /// An interface that describes a service that supports a single read-only entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetOnlyService<T>
    {
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <returns></returns>
        T Get(CompanyFile companyFile, ICompanyFileCredentials credentials);

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile companyFile, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError);

#if ASYNC
        /// <summary>
        /// Get a resource
        /// </summary>
        /// <param name="companyFile">The company file</param>
        /// <param name="credentials">The company file credentials</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> GetAsync(CompanyFile companyFile, ICompanyFileCredentials credentials, CancellationToken cancellationToken);
#endif
    }
}