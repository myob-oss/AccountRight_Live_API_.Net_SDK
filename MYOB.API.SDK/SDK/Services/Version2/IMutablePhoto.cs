using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IMutablePhoto<T> : IMutable<T>, IReadablePhoto<T> where T : BaseEntity
    {
        void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError);
        void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);
        void SavePhoto(CompanyFile cf, Guid uid, byte[] entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError);
        string SavePhoto(CompanyFile cf, Guid uid, byte[] entity, ICompanyFileCredentials credentials);
    }
}