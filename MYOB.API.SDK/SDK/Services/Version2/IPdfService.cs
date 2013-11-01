using System;
using System.IO;
using System.Net;
#if ASYNC
using System.Threading.Tasks;
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
        /// Gets an Invoice as Pdf
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="invoiceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template">The Template Name</param>
        /// <returns></returns>
        Stream GetInvoiceFormAsPdf(CompanyFile cf, Guid invoiceUid, ICompanyFileCredentials credentials, string template);

        /// <summary>
        /// Gets an Invoice as Pdf
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="invoiceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template">The Template Name</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        void GetInvoiceFormAsPdf(CompanyFile cf, Guid invoiceUid, ICompanyFileCredentials credentials, string template,
                                 Action<HttpStatusCode, Stream> onComplete, Action<Uri, Exception> onError);

#if ASYNC
        /// <summary>
        /// Gets an Invoice as Pdf Async
        /// </summary>
        /// <param name="cf"></param>
        /// <param name="invoiceUid"></param>
        /// <param name="credentials"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        Task<Stream> GetInvoiceFormAsPdfAsync(CompanyFile cf, Guid invoiceUid,
                                              ICompanyFileCredentials credentials, string template);
#endif

    }
}