﻿using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SDK.Test.Communication
{
    [TestFixture]
    public class OAuthRequestHandlerTests
    {
        private WebRequest _request;
        private MemoryStream _stream;
        private OAuthRequestHandler _handler;

        [SetUp]
        public void SetUp()
        {
            var uri = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uri.AbsoluteUri, "null");
            _request = factory.Create(uri);

            _stream = new MemoryStream();
            _request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => _stream);
#pragma warning disable 1998
            _request.GetRequestStreamAsync().Returns(async c => (Stream)_stream);
#pragma warning restore 1998

            _handler = new OAuthRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "http://desktop/"));

        }

        [Test]
        public void WhenMakingAnOauthRequestTheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange

            // act
            _handler.GetOAuthTokens(_request, "<<code>>", (code, response) => { }, (exuri, exception) => Assert.Fail(exception.Message));

            // assert
            var reader = new StreamReader(new MemoryStream(_stream.ToArray()));
            var data = reader.ReadToEnd();
            var nvc = HttpUtility.ParseQueryString(data);

            Assert.AreEqual("<<clientid>>", nvc["client_id"]);
            Assert.AreEqual("<<clientsecret>>", nvc["client_secret"]);
            Assert.AreEqual("http://desktop/", nvc["redirect_uri"]);
            Assert.AreEqual("<<code>>", nvc["code"]);
            Assert.AreEqual("CompanyFile", nvc["scope"]);
            Assert.AreEqual("authorization_code", nvc["grant_type"]);
        }

        [Test]
        public void WhenMakingAnOauthRequestRenewalTheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange

            // act
            _handler.RenewOAuthTokens(_request, new OAuthTokens() { RefreshToken = "<<refreshtoken>>" }, (code, response) => { }, (exuri, exception) => Assert.Fail(exception.Message));

            // assert
            var reader = new StreamReader(new MemoryStream(_stream.ToArray()));
            var data = reader.ReadToEnd();
            var nvc = HttpUtility.ParseQueryString(data);

            Assert.AreEqual("<<clientid>>", nvc["client_id"]);
            Assert.AreEqual("<<clientsecret>>", nvc["client_secret"]);
            Assert.AreEqual("<<refreshtoken>>", nvc["refresh_token"]);
            Assert.AreEqual("refresh_token", nvc["grant_type"]);
        }

        [Test]
        async public Task WhenMakingAnOauthRequest_Async_TheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange

            // act
            var tokens = await _handler.GetOAuthTokensAsync(_request, "<<code>>");

            // assert
            var reader = new StreamReader(new MemoryStream(_stream.ToArray()));
            var data = reader.ReadToEnd();
            var nvc = HttpUtility.ParseQueryString(data);

            Assert.AreEqual("<<clientid>>", nvc["client_id"]);
            Assert.AreEqual("<<clientsecret>>", nvc["client_secret"]);
            Assert.AreEqual("http://desktop/", nvc["redirect_uri"]);
            Assert.AreEqual("<<code>>", nvc["code"]);
            Assert.AreEqual("CompanyFile", nvc["scope"]);
            Assert.AreEqual("authorization_code", nvc["grant_type"]);
        }

        [Test]
        async public Task WhenMakingAnOauthRequestRenewal_Async_TheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange

            // act
            var tokens = await _handler.RenewOAuthTokensAsync(_request, new OAuthTokens() { RefreshToken = "<<refreshtoken>>" });

            // assert
            var reader = new StreamReader(new MemoryStream(_stream.ToArray()));
            var data = reader.ReadToEnd();
            var nvc = HttpUtility.ParseQueryString(data);

            Assert.AreEqual("<<clientid>>", nvc["client_id"]);
            Assert.AreEqual("<<clientsecret>>", nvc["client_secret"]);
            Assert.AreEqual("<<refreshtoken>>", nvc["refresh_token"]);
            Assert.AreEqual("refresh_token", nvc["grant_type"]);
        }

        [Test]
        public void WhenMakingAnOauthRequestTheCorrectHeadersAreAdded()
        {
            _handler.GetOAuthTokens(_request, "<<code>>", (code, response) => { }, (exuri, exception) => Assert.Fail(exception.Message));

            Assert.AreEqual("POST", _request.Method);
            Assert.AreEqual("application/x-www-form-urlencoded", _request.ContentType);
        }

        [Test]
        public async Task WhenMakingAnOauthRequest_Async_TheCorrectHeadersAreAdded()
        {
            await _handler.GetOAuthTokensAsync(_request, "<<code>>");

            Assert.AreEqual("POST", _request.Method);
            Assert.AreEqual("application/x-www-form-urlencoded", _request.ContentType);
        }

        [Test]
        public void WhenMakingAnOauthRequestRenewalTheCorrectHeadersAreAdded()
        {
            _handler.RenewOAuthTokens(_request, new OAuthTokens() { RefreshToken = "<<refreshtoken>>" }, (code, response) => { }, (exuri, exception) => Assert.Fail(exception.Message));

            Assert.AreEqual("POST", _request.Method);
            Assert.AreEqual("application/x-www-form-urlencoded", _request.ContentType);
        }

        [Test]
        public async Task WhenMakingAnOauthRequestRenewal_Async_TheCorrectHeadersAreAdded()
        {
            await _handler.RenewOAuthTokensAsync(_request, new OAuthTokens() { RefreshToken = "<<refreshtoken>>" });

            Assert.AreEqual("POST", _request.Method);
            Assert.AreEqual("application/x-www-form-urlencoded", _request.ContentType);
        }
    }
}
