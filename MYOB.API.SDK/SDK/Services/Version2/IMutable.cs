using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IMutable<T> : IReadable<T> where T : BaseEntity
    {
        void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError);
        void Delete(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);
        void Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError);
        string Update(CompanyFile cf, T entity, ICompanyFileCredentials credentials);
        void Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError);
        string Insert(CompanyFile cf, T entity, ICompanyFileCredentials credentials);
    }
}