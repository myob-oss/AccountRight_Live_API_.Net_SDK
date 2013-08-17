using System;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IReadablePhoto<T> : IReadable<T> where T : BaseEntity
    {
        void GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, byte[]> onComplete, Action<Uri, Exception> onError);
        byte[] GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);
    }
}