using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Communication
{
    [TestFixture]
    public class OAuthRequestHandlerTests
    {
        [Test]
        public void WhenMakingAnOauthRequestTheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange
            var uri = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uri.AbsoluteUri, "null");
            var request = factory.Create(uri);

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new OAuthRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "http://desktop/"));
            
            // act
            handler.GetOAuthTokens(request, "<<code>>", (code, response) => { }, (exuri, exception) => Assert.Fail(exception.Message));

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
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
            var uri = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uri.AbsoluteUri, "null");
            var request = factory.Create(uri);

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new OAuthRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"));

            // act
            handler.RenewOAuthTokens(request, new OAuthTokens() { RefreshToken = "<<refreshtoken>>" }, (code, response) => { }, (exuri, exception) => Assert.Fail(exception.Message));

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
            var data = reader.ReadToEnd();
            var nvc = HttpUtility.ParseQueryString(data);

            Assert.AreEqual("<<clientid>>", nvc["client_id"]);
            Assert.AreEqual("<<clientsecret>>", nvc["client_secret"]);
            Assert.AreEqual("<<refreshtoken>>", nvc["refresh_token"]);
            Assert.AreEqual("refresh_token", nvc["grant_type"]);
        }

        [Test]
        async public void WhenMakingAnOauthRequest_Async_TheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange
            var uri = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uri.AbsoluteUri, "null");
            var request = factory.Create(uri);

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new OAuthRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "http://desktop/"));

            // act
            var tokens = await handler.GetOAuthTokensAsync(request, "<<code>>");

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
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
        async public void WhenMakingAnOauthRequestRenewal_Async_TheCorrectTokensAreAddedToTheRequestBody()
        {
            // arrange
            var uri = OAuthRequestHandler.OAuthRequestUri;
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(uri.AbsoluteUri, "null");
            var request = factory.Create(uri);

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new OAuthRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"));

            // act
            var tokens = await handler.RenewOAuthTokensAsync(request, new OAuthTokens() { RefreshToken = "<<refreshtoken>>" });

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
            var data = reader.ReadToEnd();
            var nvc = HttpUtility.ParseQueryString(data);

            Assert.AreEqual("<<clientid>>", nvc["client_id"]);
            Assert.AreEqual("<<clientsecret>>", nvc["client_secret"]);
            Assert.AreEqual("<<refreshtoken>>", nvc["refresh_token"]);
            Assert.AreEqual("refresh_token", nvc["grant_type"]);
        }
    }
}
