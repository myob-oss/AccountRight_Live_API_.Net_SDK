using System;
using System.IO;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// Describes a resource that supports the fetching of PDF representations of that resource
    /// </summary>
    public interface IPdfService
    {
        /// <summary>
        /// Get resource as Pdf
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="resourceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template">The Template Name</param>
        /// <param name="title">The Title</param>
        /// <returns></returns>
        Stream GetPdf(CompanyFile cf, Guid resourceUid, ICompanyFileCredentials credentials, string template, string title=null);

        /// <summary>
        /// Get resource as Pdf
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="resourceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template">The Template Name</param>
        /// <param name="title">The Title</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void GetPdf(CompanyFile cf, Guid resourceUid, ICompanyFileCredentials credentials, string template,
                                 Action<HttpStatusCode, Stream> onComplete, Action<Uri, Exception> onError, string title = null);

#if ASYNC
        /// <summary>
        /// Get resource as Pdf 
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="resourceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template"></param>
        /// <param name="title">The Title</param>
        /// <returns></returns>
        Task<Stream> GetPdfAsync(CompanyFile cf, Guid resourceUid, ICompanyFileCredentials credentials, string template, string title = null);

        /// <summary>
        /// Get resource as Pdf
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="resourceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template"></param>
        /// <param name="title">The Title</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Stream> GetPdfAsync(CompanyFile cf, Guid resourceUid, ICompanyFileCredentials credentials, string template, CancellationToken cancellationToken, string title = null);
#endif

    }
}