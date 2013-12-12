using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using MYOB.AccountRight.SDK.Extensions;

namespace SDK.Test.Services
{
    [TestFixture]
    public class OAuthServiceTests
    {
        private IApiConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
        }

        [Test]
        public void WhenIGetTokensDelegateIReceiveDeserializedTokens()
        {
            var uriOauth = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uriOauth.AbsoluteUri, "{\"access_token\": \"<<token>>\"}");

            var service = new OAuthService(_configuration, factory);

            OAuthTokens received = null;
            service.GetTokens("code", (code, tokens) => { received = tokens; }, (uri, exception) => { Assert.Fail(); });

            Assert.IsNotNull(received);
            Assert.AreEqual("<<token>>", received.AccessToken);

        }

        [Test]
        public void WhenIRenewTokensDelegateIReceiveDeserializedTokens()
        {
            var uriOauth = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uriOauth.AbsoluteUri, "{\"access_token\": \"<<token>>\"}");

            var service = new OAuthService(_configuration, factory);

            OAuthTokens received = null;
            service.RenewTokens(new OAuthTokens(), (code, tokens) => { received = tokens; }, (uri, exception) => { Assert.Fail(); });

            Assert.IsNotNull(received);
            Assert.AreEqual("<<token>>", received.AccessToken);

        }

        [Test]
        public void WhenIGetTokensSyncIReceiveDeserializedTokens()
        {
            var uriOauth = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uriOauth.AbsoluteUri, "{\"access_token\": \"<<token>>\"}");

            var service = new OAuthService(_configuration, factory);

            OAuthTokens received = service.GetTokens("code");

            Assert.IsNotNull(received);
            Assert.AreEqual("<<token>>", received.AccessToken);

        }

        [Test]
        public void WhenIGetTokensAsyncIReceiveDeserializedTokens()
        {
            var uriOauth = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uriOauth.AbsoluteUri, "{\"access_token\": \"<<token>>\"}");

            var service = new OAuthService(_configuration, factory);

            OAuthTokens received = service.GetTokensAsync("code").Result;

            Assert.IsNotNull(received);
            Assert.AreEqual("<<token>>", received.AccessToken);

        }

        [Test]
        public void WhenIRenewTokensSyncIReceiveDeserializedTokens()
        {
            var uriOauth = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uriOauth.AbsoluteUri, "{\"access_token\": \"<<token>>\"}");

            var service = new OAuthService(_configuration, factory);

            OAuthTokens received = service.RenewTokens(new OAuthTokens());

            Assert.IsNotNull(received);
            Assert.AreEqual("<<token>>", received.AccessToken);
        }

        [Test]
        public void WhenIRenewTokensAsyncIReceiveDeserializedTokens()
        {
            var uriOauth = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uriOauth.AbsoluteUri, "{\"access_token\": \"<<token>>\"}");

            var service = new OAuthService(_configuration, factory);

            OAuthTokens received = service.RenewTokensAsync(new OAuthTokens()).Result;

            Assert.IsNotNull(received);
            Assert.AreEqual("<<token>>", received.AccessToken);
        }

        [Test]
        public void GetTokensCorrectlyHandlesWebExceptionErrors()
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var factory = new TestWebRequestFactory();
            factory.RegisterExceptionForUri<WebException>(OAuthRequestHandler.OAuthRequestUri.AbsoluteUri);

            var service = new OAuthService(_configuration, factory);

            // act
            var ex = Assert.Throws<ApiCommunicationException>(() => service.GetTokens("<<code>>"));

            // assert
            Assert.AreEqual(OAuthRequestHandler.OAuthRequestUri, ex.URI);
        }

        [Test]
        public void RenewTokensCorrectlyHandlesWebExceptionErrors()
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var factory = new TestWebRequestFactory();
            factory.RegisterExceptionForUri<WebException>(OAuthRequestHandler.OAuthRequestUri.AbsoluteUri);

            var service = new OAuthService(_configuration, factory);

            // act
            var ex = Assert.Throws<ApiCommunicationException>(() => service.RenewTokens(new OAuthTokens()));

            // assert
            Assert.AreEqual(OAuthRequestHandler.OAuthRequestUri, ex.URI);
        }

        [Test]
        public void ServiceWillUseDefaultFactoryIfNotSupplied()
        {
            // arrange
            // act
            var service = new OAuthService(_configuration);

            // assert
            Assert.IsInstanceOf<WebRequestFactory>(service.Factory);
        }
    }
}
