using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using NUnit.Framework;

namespace SDK.Test
{
    [TestFixture]
    public class ApiConfigurationTests
    {
        [Test]
        public void WhenICreateAConfigObjectItCorrectlyStoresTheSuppliedEntries()
        {
            var config = new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>", "<<apibaseurl>>");

            Assert.AreEqual("<<clientid>>", config.ClientId);
            Assert.AreEqual("<<clientsecret>>", config.ClientSecret);
            Assert.AreEqual("<<redirecturl>>", config.RedirectUrl);
            Assert.AreEqual("<<apibaseurl>>", config.ApiBaseUrl);
        }

        [Test]
        public void WhenICreateAConfigObjectTheBaseUrlDefaultsToCloudUrl()
        {
            var config = new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>");

            Assert.AreEqual("<<clientid>>", config.ClientId);
            Assert.AreEqual("<<clientsecret>>", config.ClientSecret);
            Assert.AreEqual("<<redirecturl>>", config.RedirectUrl);
            Assert.AreEqual(ApiRequestHandler.ApiRequestUri, config.ApiBaseUrl);
        }

        [Test]
        public void WhenICreateAConfigObjectForNetworkMode()
        {
            var config = new ApiConfiguration("<<apibaseurl>>");

            Assert.AreEqual("<<apibaseurl>>", config.ApiBaseUrl);
            Assert.IsNull(config.ClientId);
            Assert.IsNull(config.ClientSecret);
            Assert.IsNull(config.RedirectUrl);
        }

    }
}
