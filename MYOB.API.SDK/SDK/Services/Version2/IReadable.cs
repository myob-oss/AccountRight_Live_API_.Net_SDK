using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IReadable<T> where T : class
    {
        void Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError);
        T Get(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);
        void GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials, Action<HttpStatusCode, PagedCollection<T>> onComplete, Action<Uri, Exception> onError);
        PagedCollection<T> GetRange(CompanyFile cf, string queryString, ICompanyFileCredentials credentials);
    }
}