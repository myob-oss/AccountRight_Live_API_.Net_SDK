using System;
using System.Net;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;
using SDK.Test.Helper;
using MYOB.AccountRight.SDK.Extensions;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ServiceBaseTests
    {
        public class TestContract
        {
            public Guid UID { get; set; }
        }

        public class TestServiceBase : ServiceBase
        {
            public TestServiceBase(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) 
                : base(configuration, webRequestFactory, keyService)
            {
            }

            public UserContract Get(Uri uri, string eTag=null)
            {
                return MakeApiGetRequestSync<UserContract>(uri, null, null, eTag);
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

            public TestContract Post(Uri uri, UserContract contract)
            {
                return MakeApiPostRequestSync<UserContract, TestContract>(uri, contract, null).Value;
            }

            async public Task<UserContract> GetAsync(Uri uri, string eTag = null)
            {
                return await MakeApiGetRequestAsync<UserContract>(uri, null, eTag);
            }

            async public Task DeleteAsync(Uri uri)
            {
                await MakeApiDeleteRequestAsync(uri, null);
            }

            async public Task<string> PutAsync(Uri uri)
            {
                return await MakeApiPutRequestAsync(uri, new UserContract(), null);
            }

            async public Task<string> PostAsync(Uri uri)
            {
                return await MakeApiPostRequestAsync(uri, new UserContract(), null);
            }

            async public Task<TestContract> PostAsync(Uri uri, UserContract contract)
            {
                return await MakeApiPostRequestAsync<UserContract, TestContract>(uri, contract, null);
            }

            async public Task<TestContract> PutAsync(Uri uri, UserContract contract)
            {
                return await MakeApiPutRequestAsync<UserContract, TestContract>(uri, contract, null);
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

        private readonly Tuple<Action<TestServiceBase, Uri>, string, bool>[] _operations = new[]
            {
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.Get(uri), new UserContract() { Name = "User" }.ToJson(), true),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.Delete(uri), null, true),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.Put(uri), null, true),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.Post(uri), null, true),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.Post(uri, new UserContract()), null, true),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.GetAsync(uri).Wait(), new UserContract() { Name = "User" }.ToJson(), false),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.DeleteAsync(uri).Wait(), null, false),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.PutAsync(uri).Wait(), null, false),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.PutAsync(uri, new UserContract()).Wait(), null, false),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.PostAsync(uri).Wait(), null, false),
                new Tuple<Action<TestServiceBase, Uri>, string, bool>((@base, uri) => @base.PostAsync(uri, new UserContract()).Wait(), null, false),
            };

        [Test]
        public void OperationDoesNotUpdateKeyServiceWithNewTokensIfCurrentTokensHaveNotExpired([ValueSource("_operations")] Tuple<Action<TestServiceBase, Uri>, string, bool> operation)
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
        public void OperationUpdatesKeyServiceWithNewTokensWhenCurrentTokensHaveExpired([ValueSource("_operations")] Tuple<Action<TestServiceBase, Uri>, string, bool> operation)
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
        public void OperationCorrectlyHandlesWebExceptionErrors([ValueSource("_operations")] Tuple<Action<TestServiceBase, Uri>, string, bool> operation)
        {
            if (operation.Item3 == false)
            {
                Assert.Inconclusive("Not applicable");
            };

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
