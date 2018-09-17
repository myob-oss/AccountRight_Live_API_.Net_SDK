using System;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Payroll;
using MYOB.AccountRight.SDK.Services.Sale;

namespace MYOB.AccountRight.SDK.Services.Payroll
{
    /// <summary>
    /// A service that provides access to the <see cref="EmployeePaymentSummaryLHAmended"/> resource
    /// </summary>
    public sealed class EmployeePaymentSummaryLHAmendedService : PdfServiceBase<EmployeePaymentSummaryLHAmended>
    {
        /// <summary>
        ///  Initialise a service that can use <see cref="EmployeePaymentSummaryLHAmended"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public EmployeePaymentSummaryLHAmendedService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null)
            : base(configuration, webRequestFactory, keyService)
        {
        }

        /// <summary>
        /// Builds Uri for subresource
        /// </summary>
        /// <param name="companyFile">CompanyFile</param>
        /// <param name="uid">Unique Identifier</param>
        /// <param name="postResource"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        protected override Uri BuildUri(CompanyFile companyFile, Guid? uid = null, string postResource = null, string queryString = null)
        {
            return UriHelper.BuildUriWithSubResource(companyFile, Route, uid);
        }
        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Payroll/EmployeePaymentSummary/{0}/LHAmended"; }
        }
    }
}