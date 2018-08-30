using System;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// Uri helper utilities
    /// </summary>
    public static class UriHelper
    {
        /// <summary>
        /// Build a uri
        /// </summary>
        /// <param name="companyFile"></param>
        /// <param name="route"></param>
        /// <param name="uid"></param>
        /// <param name="postResource"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static Uri BuildUri(CompanyFile companyFile, string route, Guid? uid = null, string postResource = null, string queryString = null)
        {
            var qs = string.IsNullOrEmpty(queryString) ? string.Empty : queryString.StartsWith("?") ? queryString : "?" + queryString;
            return new Uri(string.Format("{0}/{1}/{2}{3}{4}", companyFile.Uri, route, uid.HasValue ? uid.Value.ToString() : string.Empty, postResource ?? string.Empty, qs));
        }

        /// <summary>
        /// Build a uri for subresource
        /// </summary>
        /// <param name="companyFile"></param>
        /// <param name="route"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static Uri BuildUriWithSubResource(CompanyFile companyFile, string route, Guid? uid = null)
        {
            return new Uri(string.Format("{0}/{1}", companyFile.Uri, string.Format(route, uid.HasValue ? uid.Value.ToString() : string.Empty)));
        }
    }
}
