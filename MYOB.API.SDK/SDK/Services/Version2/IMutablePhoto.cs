using System;
using System.Net;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;

namespace MYOB.AccountRight.SDK.Services
{
    public interface IMutablePhoto<T> : IMutable<T>, IReadablePhoto<T> where T : BaseEntity
    {
        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        void DeletePhoto(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials);

#if ASYNC
        /// <summary>
        /// Delete a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task DeletePhotoAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials); 
#endif

        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        void SavePhoto(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError);

        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        string SavePhoto(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials);

#if ASYNC
        /// <summary>
        /// Save/Update a photo of an entity
        /// </summary>
        /// <param name="cf">A company file that has been retrieved</param>
        /// <param name="uid">The identifier of the entity to retrieve</param>
        /// <param name="photoData">The image binary</param>
        /// <param name="credentials">The credentials to access the company file</param>
        /// <returns></returns>
        Task<string> SavePhotoAsync(CompanyFile cf, Guid uid, byte[] photoData, ICompanyFileCredentials credentials); 
#endif
    }
}