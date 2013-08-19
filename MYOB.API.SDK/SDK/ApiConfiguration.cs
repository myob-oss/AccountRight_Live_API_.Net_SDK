using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// Enter your application client id and secret here
    /// 
    /// https://my.myob.com.au/Bd/pages/DevAppList.aspx
    /// </summary>
    public class ApiConfiguration : IApiConfiguration
    {
        public ApiConfiguration(string clientId, string clientSecret, string redirectUrl, string apiBaseUrl = "https://api.myob.com/accountright")
        {
            ApiBaseUrl = apiBaseUrl;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
        }

        public ApiConfiguration(string apiBaseUrl) : this(null, null, null, apiBaseUrl)
        {}

        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string RedirectUrl { get; private set; }
        public string ApiBaseUrl { get; private set; }
    }

    public class CompanyFileCredentials : ICompanyFileCredentials
    {
        public CompanyFileCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
