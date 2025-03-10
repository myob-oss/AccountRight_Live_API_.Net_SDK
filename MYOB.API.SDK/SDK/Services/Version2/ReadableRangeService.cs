﻿using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
#if ASYNC
using System.Threading.Tasks;
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReadableRangeService<T> : ServiceBase, IReadableRange<T> where T : class
    {
        /// <summary>
        /// Initialise base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        /// <param name="apiRequestHandlerFactory">A custom implementation of the <see cref="IApiRequestHandlerFactory"/>, if one is not supplied a default <see cref="ApiRequestHandlerFactory"/> will be used.</param>
        protected ReadableRangeService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService, IApiRequestHandlerFactory apiRequestHandlerFactory = null)
            : base(configuration, webRequestFactory, keyService, apiRequestHandlerFactory)
        {
        }

        /// <summary>
        /// The route to the service (after the company file identifier)
        /// </summary>
        public abstract string Route { get; }

        /// <exclude/>
        protected virtual Uri BuildUri(CompanyFile companyFile, Guid? uid = null, string postResource = null, string queryString = null)
        {
            return UriHelper.BuildUri(companyFile, Route, uid, postResource, queryString);
        }

        /// <exclude/>
        protected Uri ValidateUri(CompanyFile cf, Uri uri)
        {
            if (!uri.AbsoluteUri.ToLowerInvariant().StartsWith(cf.Uri.AbsoluteUri.ToLowerInvariant()))
                throw new ArgumentException("The supplied Uri is not valid for the company file.", "uri");
            var tmpUri = BuildUri(cf);
            if (!uri.AbsoluteUri.ToLowerInvariant().StartsWith(tmpUri.AbsoluteUri.ToLowerInvariant()))
                throw new ArgumentException("The supplied Uri is not valid for the current service.", "uri");
            if (!Regex.Match(uri.AbsoluteUri, ".*/([a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12})$", RegexOptions.IgnoreCase).Success)
                throw new ArgumentException("The supplied Uri must end with a UID.", "uri");
            return uri;
        }

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete">The action to call when the operation is complete</param>
        /// <param name="onError">The action to call when the operation has an error</param>
        /// <param name="eTag">The <see cref="PagedCollection&lt;T&gt;.ETag" /> from a previously fetched entity</param>
        public virtual void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, Action<HttpStatusCode, PagedCollection<T>> onComplete, Action<Uri, Exception> onError, string eTag = null)
        {
            MakeApiGetRequestDelegate(BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart('?'))), credentials, onComplete, onError, eTag);
        }

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="PagedCollection&lt;T&gt;.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public virtual PagedCollection<T> GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, string eTag = null)
        {
            return MakeApiGetRequestSync<PagedCollection<T>>(BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart('?'))), credentials, eTag);
        }

#if ASYNC
        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="eTag">The <see cref="PagedCollection&lt;T&gt;.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public virtual Task<PagedCollection<T>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, string eTag = null)
        {
            return this.GetRangeAsync(cf, queryString, credentials, CancellationToken.None, eTag);
        }

        /// <summary>
        /// Retrieve a paged list of entities
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="queryString">An odata filter</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="cancellationToken"></param>
        /// <param name="eTag">The <see cref="PagedCollection&lt;T&gt;.ETag" /> from a previously fetched entity</param>
        /// <returns></returns>
        public virtual Task<PagedCollection<T>> GetRangeAsync(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag = null)
        {
            return this.MakeApiGetRequestAsync<PagedCollection<T>>(this.BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart('?'))), credentials, cancellationToken, eTag);
        }
#endif
    }
}