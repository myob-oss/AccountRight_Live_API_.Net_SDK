﻿using System;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Services.GeneralLedger
{
    using System.Threading;

    using MYOB.AccountRight.SDK.Contracts;

    /// <summary>
    /// A service that provides access to the <see cref="CategoryRegister"/> resource
    /// </summary>
    public sealed class CategoryRegisterService : ReadableService<CategoryRegister>
    {
        /// <summary>
        /// Initialise a service that can use <see cref="CategoryRegister"/> resources
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        public CategoryRegisterService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory = null, IOAuthKeyService keyService = null, IApiRequestHandlerFactory apiRequestHandlerFactory = null)
            : base(configuration, webRequestFactory, keyService, apiRequestHandlerFactory)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public override string Route
        {
            get { return "GeneralLedger/CategoryRegister"; }
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <param name="query">query</param>
        /// <returns></returns>
        public override CategoryRegister Get(Contracts.CompanyFile cf, System.Guid uid, ICompanyFileCredentials credentials, string eTag = null, string query = null)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        public override void Get(Contracts.CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode, CategoryRegister> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public override CategoryRegister Get(Contracts.CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, string eTag = null)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        public override void Get(Contracts.CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<System.Net.HttpStatusCode, CategoryRegister> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            throw new NotSupportedException();
        }

#if ASYNC
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public override Task<CategoryRegister> GetAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            return Task.Factory.StartNew<CategoryRegister>(() => { throw new NotSupportedException(); });      
        }

        /// <summary>
        /// Retrieve an entity
        /// </summary>
        /// <param name="cf">A company file reference that has been retrieved</param>
        /// <param name="uri">The uri of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="BaseEntity.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public override Task<CategoryRegister> GetAsync(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            return Task.Factory.StartNew<CategoryRegister>(() => { throw new NotSupportedException(); }); 
        }
#endif
    }
}