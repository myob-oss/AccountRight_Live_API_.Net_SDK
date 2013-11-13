using System;
using MYOB.AccountRight.SDK.Contracts;

namespace MYOB.AccountRight.SDK.Services
{
    internal class UriHelper
    {
        public static Uri BuildUri(CompanyFile companyFile, string route, Guid? uid = null, string postResource = null, string queryString = null)
        {
            var qs = string.IsNullOrEmpty(queryString) ? string.Empty : queryString.StartsWith("?") ? queryString : "?" + queryString;
            return new Uri(string.Format("{0}/{1}/{2}{3}{4}", companyFile.Uri, route, uid.HasValue ? uid.Value.ToString() : string.Empty, postResource ?? string.Empty, qs));
        }
    }
}
