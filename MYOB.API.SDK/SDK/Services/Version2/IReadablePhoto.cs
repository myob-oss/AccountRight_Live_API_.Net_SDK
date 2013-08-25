using System;
using System.Net;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IReadablePhoto<T> : IReadable<T> where T : BaseEntity
    {
        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode, byte[]> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        byte[] GetPhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);

        /// <summary>
        /// Get the photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<byte[]> GetPhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);
    }
}