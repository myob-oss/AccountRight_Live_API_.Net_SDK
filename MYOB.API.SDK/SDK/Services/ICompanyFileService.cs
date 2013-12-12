using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// Describes the methods exposed by the <see cref="CompanyFileService"/>
    /// </summary>
    public interface ICompanyFileService
    {
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void GetRange(Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <returns></returns>
        CompanyFile[] GetRange();

#if ASYNC
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <returns></returns>
        Task<CompanyFile[]> GetRangeAsync();

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CompanyFile[]> GetRangeAsync(CancellationToken cancellationToken);
        
#endif
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void GetRange(string queryString, Action<HttpStatusCode, CompanyFile[]> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">An odata filter</param>
        /// <returns></returns>
        CompanyFile[] GetRange(string queryString);

#if ASYNC
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <returns></returns>
        Task<CompanyFile[]> GetRangeAsync(string queryString);

        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">e.g. An ODATA filter</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CompanyFile[]> GetRangeAsync(string queryString, CancellationToken cancellationToken);        
#endif
        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void Get(CompanyFile cf, ICompanyFileCredentials credentials, Action<HttpStatusCode, CompanyFileWithResources> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        CompanyFileWithResources Get(CompanyFile cf, ICompanyFileCredentials credentials);

#if ASYNC
        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<CompanyFileWithResources> GetAsync(CompanyFile cf, ICompanyFileCredentials credentials);

        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CompanyFileWithResources> GetAsync(CompanyFile cf, ICompanyFileCredentials credentials, CancellationToken cancellationToken); 
#endif
    }
}