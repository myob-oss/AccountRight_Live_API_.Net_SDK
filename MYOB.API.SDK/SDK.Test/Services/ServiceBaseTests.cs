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
using NUnit.Framework;
using SDK.Test.Communication;
using SDK.Test.Helper;
using MYOB.AccountRight.SDK.Extensions;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ServiceBaseTests
    {
        public class TestServiceBase : ServiceBase
        {
            public TestServiceBase(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
                : base(configuration, webRequestFactory, keyService)
            {
            }

            public UserContract Get(Uri uri)
            {
                return MakeApiGetRequestSync<UserContract>(uri, null);
            }

            public void Delete(Uri uri)
            {
                MakeApiDeleteRequestSync(uri, null);
            }

            public string Put(Uri uri)
            {
                return MakeApiPutRequestSync(uri, new UserContract(), null);
            }

            public string Post(Uri uri)
            {
                return MakeApiPostRequestSync(uri, new UserContract(), null);
            }

        }

        [Test]
        public void GetNonWebExceptionsAreWrappedIfThrown()
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var factory = new TestWebRequestFactory();
            var service = new TestServiceBase(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), factory, null);
            factory.RegisterExceptionForUri<InvalidOperationException>(apiUri.AbsoluteUri);

            // act
            var ex = Assert.Throws<ApiOperationException>(() => service.Get(apiUri));

            // assert
            Assert.IsInstanceOf<InvalidOperationException>(ex.InnerException);
        }

        [Test]
        public void GetWebExceptionsAreWrappedIfThrown()
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var factory = new TestWebRequestFactory();
            var service = new TestServiceBase(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), factory, null);
            factory.RegisterExceptionForUri<WebException>(apiUri.AbsoluteUri);

            // act
            var ex = Assert.Throws<ApiCommunicationException>(() => service.Get(apiUri));

            // assert
            Assert.AreEqual(apiUri, ex.URI);
            Assert.IsInstanceOf<InvalidOperationException>(ex.InnerException);
        }

        private readonly Tuple<Action<TestServiceBase, Uri>, string>[] _operations = new[]
            {
                new Tuple<Action<TestServiceBase, Uri>, string>((@base, uri) => @base.Get(uri), new UserContract() { Name = "User" }.ToJson()),
                new Tuple<Action<TestServiceBase, Uri>, string>((@base, uri) => @base.Delete(uri), null),
                new Tuple<Action<TestServiceBase, Uri>, string>((@base, uri) => @base.Put(uri), null),
                new Tuple<Action<TestServiceBase, Uri>, string>((@base, uri) => @base.Post(uri), null),
            };

        [Test]
        public void OperationDoesNotUpdateKeyServiceWithNewTokensIfCurrentTokensHaveNotExpired([ValueSource("_operations")] Tuple<Action<TestServiceBase, Uri>, string> operation)
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var keyService = new SimpleOAuthKeyService()
                {
                    OAuthResponse = new OAuthTokens() {AccessToken = "<<accesstoken>>", RefreshToken = "<<refreshtoken>>", ExpiresIn = 1000}
                };
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(OAuthRequestHandler.OAuthRequestUri.AbsoluteUri, new OAuthTokens() { AccessToken = "<<newacesstoken>>" }.ToJson());
            factory.RegisterResultForUri(apiUri.AbsoluteUri, operation.Item2);

            var service = new TestServiceBase(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), factory, keyService);

            // act
            operation.Item1(service, apiUri);

            // assert
            Assert.AreEqual("<<accesstoken>>", keyService.OAuthResponse.AccessToken);
        }

        [Test]
        public void OperationUpdatesKeyServiceWithNewTokensWhenCurrentTokensHaveExpired([ValueSource("_operations")] Tuple<Action<TestServiceBase, Uri>, string> operation)
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var keyService = new SimpleOAuthKeyService()
            {
                OAuthResponse = new OAuthTokens() { AccessToken = "<<accesstoken>>", RefreshToken = "<<refreshtoken>>", ExpiresIn = 10 }
            };
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(OAuthRequestHandler.OAuthRequestUri.AbsoluteUri, new OAuthTokens() { AccessToken = "<<newaccesstoken>>" }.ToJson());
            factory.RegisterResultForUri(apiUri.AbsoluteUri, operation.Item2);

            var service = new TestServiceBase(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), factory, keyService);

            // act
            operation.Item1(service, apiUri);

            // assert
            Assert.AreEqual("<<newaccesstoken>>", keyService.OAuthResponse.AccessToken);
        }

        [Test]
        public void OperationCorrectlyHandlesWebExceptionErrors([ValueSource("_operations")] Tuple<Action<TestServiceBase, Uri>, string> operation)
        {
            // arrange
            var apiUri = ApiRequestHandler.ApiRequestUri;

            var keyService = new SimpleOAuthKeyService()
            {
                OAuthResponse = new OAuthTokens() { AccessToken = "<<accesstoken>>", RefreshToken = "<<refreshtoken>>", ExpiresIn = 10 }
            };
            var factory = new TestWebRequestFactory();
            factory.RegisterResultForUri(OAuthRequestHandler.OAuthRequestUri.AbsoluteUri, new OAuthTokens() { AccessToken = "<<newaccesstoken>>" }.ToJson());
            factory.RegisterExceptionForUri<WebException>(apiUri.AbsoluteUri);

            var service = new TestServiceBase(new ApiConfiguration("<<clientid>>", "<<clientsecret>>", "<<redirecturl>>"), factory, keyService);

            // act
            var ex = Assert.Throws<ApiCommunicationException>(() => operation.Item1(service, apiUri));

            // assert
            Assert.AreEqual(apiUri, ex.URI);
        }
    }
}
