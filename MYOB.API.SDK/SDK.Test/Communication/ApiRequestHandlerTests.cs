using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
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
        public void DuringGetRequestExpectedHeadersAreAttached()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", new UserContract(){Name = "David"}.ToJson());
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            handler.Get<UserContract>(request, (code, response) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.IsTrue(request.Headers[HttpRequestHeader.Authorization].StartsWith("Bearer"));
            Assert.IsTrue(request.Headers[HttpRequestHeader.AcceptEncoding].Split(new []{','}).Contains("gzip"));

            Assert.AreEqual("<<clientid>>", request.Headers["x-myobapi-key"]);
            Assert.AreEqual("v2", request.Headers["x-myobapi-version"]);
            Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass")), request.Headers["x-myobapi-cftoken"]); 
        }

        [Test]
        public void DuringDeleteRequestExpectedHeadersAreAttached()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            handler.Delete(request, (code) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("DELETE", request.Method);
            Assert.IsTrue(request.Headers[HttpRequestHeader.Authorization].StartsWith("Bearer"));
            Assert.IsTrue(request.Headers[HttpRequestHeader.AcceptEncoding].Split(new[] { ',' }).Contains("gzip"));

            Assert.AreEqual("<<clientid>>", request.Headers["x-myobapi-key"]);
            Assert.AreEqual("v2", request.Headers["x-myobapi-version"]);
            Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass")), request.Headers["x-myobapi-cftoken"]);
        }

        [Test]
        public void DuringPutRequestExpectedHeadersAreAttached()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            handler.Put(request, new UserContract() { Name = "Paul" }, (code, location) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("PUT", request.Method);
            Assert.IsTrue(request.Headers[HttpRequestHeader.Authorization].StartsWith("Bearer"));
            Assert.IsTrue(request.Headers[HttpRequestHeader.AcceptEncoding].Split(new[] { ',' }).Contains("gzip"));

            Assert.AreEqual("<<clientid>>", request.Headers["x-myobapi-key"]);
            Assert.AreEqual("v2", request.Headers["x-myobapi-version"]);
            Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass")), request.Headers["x-myobapi-cftoken"]);
        }

        [Test]
        public void DuringPostRequestExpectedHeadersAreAttached()
        {
            // arrange
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri("http://localhost", "");
            var request = factory.Create(new Uri("http://localhost"));

            var handler = new ApiRequestHandler(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), new CompanyFileCredentials("user", "pass"));

            // act
            handler.Post(request, new UserContract() { Name = "Paul" }, (code, location) => { }, (uri, exception) => Assert.Fail(exception.Message));

            // assert
            Assert.AreEqual("POST", request.Method);
            Assert.IsTrue(request.Headers[HttpRequestHeader.Authorization].StartsWith("Bearer"));
            Assert.IsTrue(request.Headers[HttpRequestHeader.AcceptEncoding].Split(new[] { ',' }).Contains("gzip"));

            Assert.AreEqual("<<clientid>>", request.Headers["x-myobapi-key"]);
            Assert.AreEqual("v2", request.Headers["x-myobapi-version"]);
            Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass")), request.Headers["x-myobapi-cftoken"]);
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


    }
}
