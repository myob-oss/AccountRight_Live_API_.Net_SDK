﻿using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2.Banking;

namespace MYOB.AccountRight.SDK.Services.Banking
{
    /// <summary>
    /// a service that provides access to <see cref="Statement"/> resource
    /// </summary>
    public class StatementService : ReadableService<Statement>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="Statement"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public StatementService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService, IApiRequestHandlerFactory apiRequestHandlerFactory = null)
            : base(configuration, webRequestFactory, keyService, apiRequestHandlerFactory)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "Banking/Statement"; }
        }
    }
}
