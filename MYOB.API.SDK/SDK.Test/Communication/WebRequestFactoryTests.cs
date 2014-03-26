using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Communication;
using NUnit.Framework;


namespace SDK.Test.Communication
{
    using System.Net.Cache;

    using MYOB.AccountRight.SDK;

    [TestFixture]
    public class WebRequestFactoryTests
    {
        private WebRequestFactory CreateWebRequestFactory(IApiConfiguration configuration = null)
        {
            return new WebRequestFactory(configuration ?? new ApiConfiguration(string.Empty));
        }

        [Test]
        public void WhenICreateAWebRequestObjectItIsPopulatedWithSuppliedUri()
        {
            const string uri = "http://localhost";

            var request1 = this.CreateWebRequestFactory().Create(new Uri(uri));

            Assert.AreEqual(new Uri(uri), request1.RequestUri);
        }

        [Test]
        public void WhenICreateSeveralWebRequestObjectTheyAreNotTheSameObject()
        {
            const string uri = "http://localhost";

            var request1 = this.CreateWebRequestFactory().Create(new Uri(uri));
            var request2 = this.CreateWebRequestFactory().Create(new Uri(uri));

            Assert.AreNotSame(request1, request2);
        }

        [Test]
        public void WhenISupplyAnAcceptHeader_ItIsAppliedTo_TheCreatedWebRequestObject()
        {
			// arrange
            const string uri = "http://localhost";
            const string mime = "application/pdf";

			// act
            var request = this.CreateWebRequestFactory().Create(new Uri(uri), mime);

			// assert
            Assert.IsInstanceOf<HttpWebRequest>(request);
            Assert.AreEqual(mime, (request as HttpWebRequest).Accept);  
        }

        [Test]
        public void HttpCachePolicy_Is_Set_On_Webrequest()
        {
            var requestCachePoliciy = new RequestCachePolicy();

            var factory = this.CreateWebRequestFactory(new ApiConfiguration(string.Empty) { RequestCachePolicy = requestCachePoliciy });

            var request = factory.Create(new Uri("http://asdf/"));

            Assert.AreSame(requestCachePoliciy, request.CachePolicy);
        }
    }
}
