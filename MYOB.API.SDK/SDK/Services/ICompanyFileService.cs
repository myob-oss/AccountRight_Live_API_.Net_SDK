using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    public interface ICompanyFileService
    {
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
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
        
#endif
        /// <summary>
        /// Get list of available company fies
        /// </summary>
        /// <param name="queryString">An odata filter</param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
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
        /// <param name="queryString">An odata filter</param>
        /// <returns></returns>
        Task<CompanyFile[]> GetRangeAsync(string queryString);        
#endif
        /// <summary>
        /// Get a company file entry with the list of available resources
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
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
#endif
    }
}