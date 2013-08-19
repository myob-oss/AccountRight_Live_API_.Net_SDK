using System;
using System.Net;
using System.Text.RegularExpressions;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    public abstract class ReadableService<T> : ServiceBase, IReadable<T> where T : class
    {
        public abstract string Route { get; }

        protected ReadableService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
            : base(configuration, webRequestFactory, keyService)
        {
        }

        private static Uri BuildUri(CompanyFile companyFile, string route, Guid? uid = null, string postResource = null)
        {
            return new Uri(string.Format("{0}/{1}/{2}{3}", companyFile.Uri, route, uid.HasValue ? uid.Value.ToString() : string.Empty, postResource ?? string.Empty));
        }

        protected Uri BuildUri(CompanyFile companyFile, Guid? uid = null, string postResource = null)
        {
            return BuildUri(companyFile, Route, uid, postResource);
        }

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

        public virtual void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestAsync(BuildUri(cf, uid), credentials, onComplete, onError);
        }

        public virtual T Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<T>(BuildUri(cf, uid), credentials);
        }

        public virtual void Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestAsync(ValidateUri(cf, uri), credentials, onComplete, onError);
        }

        public virtual T Get(CompanyFile cf, Uri uri, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<T>(ValidateUri(cf,uri), credentials);
        }

        public virtual void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, Action<HttpStatusCode, PagedCollection<T>> onComplete, Action<Uri, Exception> onError)
        {
            MakeApiGetRequestAsync(BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), credentials, onComplete, onError);
        }

        public virtual PagedCollection<T> GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials)
        {
            return MakeApiGetRequestSync<PagedCollection<T>>(BuildUri(cf, null, queryString.Maybe(_ => "?" + _.TrimStart(new[] { '?' }))), credentials);
        }

    }
}