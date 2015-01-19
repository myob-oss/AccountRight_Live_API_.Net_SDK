using System;
using System.Net;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.External
{
    [TestFixture]
    public class ServerTests
    {
        [Test, Explicit]
        public void TestServerConnectionWithNoOAuth()
        {
            var config = new ApiConfiguration("<<a secret id>>", "<<a secret key>>", "");
            var ks = new SimpleOAuthKeyService();
            ks.OAuthResponse = new OAuthTokens(){AccessToken = string.Empty, ExpiresIn = 2000, ReceivedTime = DateTime.UtcNow};
            var service = new CompanyFileService(config, new WebRequestFactory(config), ks);

            var ex = Assert.Throws<ApiCommunicationException>(() => service.GetRange());

            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
        }
    }
}
