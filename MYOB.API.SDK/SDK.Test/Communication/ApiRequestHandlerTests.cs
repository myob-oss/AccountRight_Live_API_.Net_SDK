using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Extensions;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Communication
{
    [TestFixture]
    public class ApiRequestHandlerTests
    {
        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void DuringGetRequestExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract(){Name = "David"}.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            handler.Get<UserContract>(request, (code, response) => { }, (uri, exception) => Assert.Fail(exception.Message), null);

            // assert
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);

            var version = typeof (ApiRequestHandler).Assembly.GetName().Version.ToString(3);
            var userAgent = request.Headers[HttpRequestHeader.UserAgent];
            Assert.IsTrue(userAgent.Contains(string.Format("MYOB-ARL-SDK/{0}", version)));
            Assert.IsNull(request.Headers[HttpRequestHeader.IfNoneMatch]);
        }

        [Test]
        public void DuringGetRequest_IfNoneMatchHeaderAttached_IfSupplyETag()
        {
            // arrange
            var eTag = "123456789";
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract() { Name = "David" }.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            handler.Get<UserContract>(request, (code, response) => { }, (uri, exception) => Assert.Fail(exception.Message), eTag);

            // assert
            Assert.AreEqual(eTag, request.Headers[HttpRequestHeader.IfNoneMatch]);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        async public Task DuringGetRequest_Async_ExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract() { Name = "David" }.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            var res = await handler.GetAsync<UserContract>(request, null);

            // assert
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
            Assert.IsNull(request.Headers[HttpRequestHeader.IfNoneMatch]);
        }

        [Test]
        async public Task DuringGetRequest_Async_IfNoneMatchHeaderAttached_IfSupplyETag()
        {
            // arrange
            var eTag = "123456789";
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract() { Name = "David" }.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            var res = await handler.GetAsync<UserContract>(request, eTag);

            // assert
            Assert.AreEqual(eTag, request.Headers[HttpRequestHeader.IfNoneMatch]);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void DuringDeleteRequestExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), 
                supplyCredentials ? new CompanyFileCredentials("user", "pass"): null, supplyOAuth ? new OAuthTokens() : null);

            // act
            handler.Delete(request, (code) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("DELETE", request.Method);
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
        }

        private static void AssertStandardHeaders(bool supplyCredentials, bool supplyOAuth, WebRequest request)
        {
            if (supplyOAuth)
                Assert.IsTrue(request.Headers[HttpRequestHeader.Authorization].StartsWith("Bearer"));
            else
                Assert.IsNull(request.Headers[HttpRequestHeader.Authorization]);
        
            Assert.IsTrue(request.Headers[HttpRequestHeader.AcceptEncoding].Split(new[] {','}).Contains("gzip"));

            Assert.AreEqual("v2", request.Headers["x-myobapi-version"]);

            if (supplyCredentials)
                Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass")), request.Headers["x-myobapi-cftoken"]);
            else
                Assert.IsNull(request.Headers["x-myobapi-cftoken"]);
            }

        [Test]
        [TestCase(true, true)]
        public void TestEmptyCredentials(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract() { Name = "David" }.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("", "") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            handler.Get<UserContract>(request, (code, response) => { }, (uri, exception) => Assert.Fail(exception.Message), null);

            // assert
            AssertEmptyCredentialsHeaders(supplyOAuth, request);

            var version = typeof(ApiRequestHandler).Assembly.GetName().Version.ToString(3);
            var userAgent = request.Headers[HttpRequestHeader.UserAgent];
            Assert.IsTrue(userAgent.Contains(string.Format("MYOB-ARL-SDK/{0}", version)));
            Assert.IsNull(request.Headers[HttpRequestHeader.IfNoneMatch]);
        }

        private static void AssertEmptyCredentialsHeaders(bool supplyOAuth, WebRequest request)
        {
            if (supplyOAuth)
                Assert.IsTrue(request.Headers[HttpRequestHeader.Authorization].StartsWith("Bearer"));
            else
                Assert.IsNull(request.Headers[HttpRequestHeader.Authorization]);

            Assert.IsTrue(request.Headers[HttpRequestHeader.AcceptEncoding].Split(new[] { ',' }).Contains("gzip"));

            Assert.AreEqual("v2", request.Headers["x-myobapi-version"]);
            Assert.IsNull(request.Headers["x-myobapi-cftoken"]);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        async public Task DuringDeleteRequest_Async_ExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            await handler.DeleteAsync(request);

            // assert
            Assert.AreEqual("DELETE", request.Method);
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void DuringPutRequestExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            handler.Put(request, new UserContract() { Name = "Paul" }, (code, location) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("PUT", request.Method);
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        async public Task DuringPutRequest_Async_ExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            await handler.PutAsync(request, new UserContract() { Name = "Paul" });

            // assert
            Assert.AreEqual("PUT", request.Method);
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void DuringPostRequestExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            handler.Post(request, new UserContract() { Name = "Paul" }, (code, location) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("POST", request.Method);
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
        }

        private class ExpectedResult
        {
            public Guid UID { get; set; }
        }

        private class Parameter { }

        [Test]
        public void PostRequest_Return_Response()
        {
            // arrange
            var expected = new ExpectedResult { UID = Guid.NewGuid() };
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", expected.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            ExpectedResult receivedEntity = null;
            handler.Post<Parameter, ExpectedResult>(request, new Parameter(), (code, location, response) => { receivedEntity = response; }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual(expected.UID, receivedEntity.UID);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        async public Task DuringPostRequest_Async_ExpectedHeadersAreAttached(bool supplyCredentials, bool supplyOAuth)
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"),
                supplyCredentials ? new CompanyFileCredentials("user", "pass") : null, supplyOAuth ? new OAuthTokens() : null);

            // act
            await handler.PostAsync(request, new UserContract() { Name = "Paul" });

            // assert
            Assert.AreEqual("POST", request.Method);
            AssertStandardHeaders(supplyCredentials, supplyOAuth, request);
        }

        [Test]
        public void PostAsyncRequest_Return_Response()
        {
            // arrange
            var expected = new ExpectedResult { UID = Guid.NewGuid() };
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", expected.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            var receivedEntity = handler.PostAsync<Parameter, ExpectedResult>(request, new Parameter()).Result;

            // assert
            Assert.AreEqual(expected.UID, receivedEntity.UID);
        }

        [Test]
        public void PutAsyncRequest_Return_Response()
        {
            // arrange
            var expected = new ExpectedResult { UID = Guid.NewGuid() };
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", expected.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            var receivedEntity = handler.PutAsync<Parameter, ExpectedResult>(request, new Parameter()).Result;

            // assert
            Assert.AreEqual(expected.UID, receivedEntity.UID);
        }

        [Test]
        public void TheEntityIsPlacedOnTheOutgoingStreamInJsonFormatDuringPut()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);

            // act
            handler.Put(request, new UserContract() { Name = "Paul" }, (code, location) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
            var data = reader.ReadToEnd().FromJson<UserContract>();

            Assert.AreEqual("Paul", data.Name);
        }

        [Test]
        async public Task TheEntityIsPlacedOnTheOutgoingStreamInJsonFormatDuringPutAsync()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
#pragma warning disable 1998
            request.GetRequestStreamAsync().Returns(async c => (Stream)stream);
#pragma warning restore 1998

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);

            // act
            await handler.PutAsync(request, new UserContract() { Name = "Paul" });

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
            var data = reader.ReadToEnd().FromJson<UserContract>();

            Assert.AreEqual("Paul", data.Name);
        }

        [Test]
        public void TheEntityIsPlacedOnTheOutgoingStreamInJsonFormatDuringPost()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);

            // act
            handler.Post(request, new UserContract() { Name = "Paul" }, (code, location) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
            var data = reader.ReadToEnd().FromJson<UserContract>();

            Assert.AreEqual("Paul", data.Name);
        }

        [Test]
        async public Task TheEntityIsPlacedOnTheOutgoingStreamInJsonFormatDuringPostAsync()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
#pragma warning disable 1998
            request.GetRequestStreamAsync().Returns(async c => (Stream)stream);
#pragma warning restore 1998

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);

            // act
            await handler.PostAsync(request, new UserContract() { Name = "Paul" });

            // assert
            var reader = new StreamReader(new MemoryStream(stream.ToArray()));
            var data = reader.ReadToEnd().FromJson<UserContract>();

            Assert.AreEqual("Paul", data.Name);
        }

        [Test]
        public void TheLocationIsReturnedAfterASuccesfulPost()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "", HttpStatusCode.OK, "http://localhost/ABC");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);
            string savedLocation = null;

            // act
            handler.Post(request, new UserContract() {Name = "Paul"}, (code, location) =>
            { savedLocation = location; }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("http://localhost/ABC", savedLocation);
        }

        [Test]
        async public Task TheLocationIsReturnedAfterASuccesfulPostAsync()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "", HttpStatusCode.OK, "http://localhost/ABC");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);

            // act
            var res = await handler.PostAsync(request, new UserContract() { Name = "Paul" });

            // assert
            Assert.AreEqual("http://localhost/ABC", res);
        }

        [Test]
        public void TheLocationIsReturnedAfterASuccesfulPut()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "", HttpStatusCode.OK, "http://localhost/ABC");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);
            string savedLocation = null;

            // act
            handler.Put(request, new UserContract() { Name = "Paul" }, (code, location) =>
            { savedLocation = location; }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("http://localhost/ABC", savedLocation);
        }

        [Test]
        async public Task TheLocationIsReturnedAfterASuccesfulPutAsync()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "", HttpStatusCode.OK, "http://localhost/ABC");
            var request = factory.Create(new Uri("http://localhost"));

            var stream = new MemoryStream();
            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => stream);

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), null);

            // act
            var res = await handler.PutAsync(request, new UserContract() { Name = "Paul" });

            // assert
            Assert.AreEqual("http://localhost/ABC", res);
        }

        [Test]
        public void IgnoreException_SwallowsExceptions()
        {
             Assert.DoesNotThrow(() => ApiRequestHelper.IgnoreError(() => { throw new Exception(); }));
        }

        [Test]
        public void AuthorizationHeaderNotAppliedWhenClientCertificateAttached()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract() { Name = "David" }.ToJson());
            var request = factory.Create(new Uri("http://localhost"));
            (request as HttpWebRequest).ClientCertificates.Add(new X509Certificate());

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            handler.Get<UserContract>(request, (code, response) => { }, (uri, exception) => Assert.Fail(exception.Message), null);

            // assert
            Assert.IsNull(request.Headers[HttpRequestHeader.Authorization]);
        }
    }
}
