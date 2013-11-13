using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Extensions;
using MYOB.AccountRight.SDK.Services;
using NSubstitute;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ReadableServiceTests
    {
        public class TestReadOnlyService : ReadableService<UserContract>
        {
            public TestReadOnlyService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) : base(configuration, webRequestFactory, keyService)
            {
            }

            internal override string Route
            {
                get { return "Test/User/Contract"; }
            }
        }

        private IApiConfiguration _configuration;
        private TestWebRequestFactory _webFactory;
        private TestReadOnlyService _service;
        private static Guid _uid;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webFactory = new TestWebRequestFactory();
            _service = new TestReadOnlyService(_configuration, _webFactory, null);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>[] _getActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("Async", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.Get(cf, _uid, null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Get(cf, _uid, null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, _uid, null).Result;
                    }),
            };


        [Test]
        public void WeGetUsingCompanyFileBaseUrl([ValueSource("_getActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid, new UserContract() { UID = _uid }.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(_uid, received.UID, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>[] _getRangeActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>("Delegate", 
                    (service, cf) =>
                    {
                        PagedCollection<UserContract> received = null;
                        service.GetRange(cf, null, null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>("Sync", 
                    (service, cf) =>
                    {
                        return service.GetRange(cf, null, null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetRangeAsync(cf, null, null).Result;
                    }),
            };


        [Test]
        public void WeGetRangeUsingCompanyFileBaseUrl([ValueSource("_getRangeActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract", new PagedCollection<UserContract> { Count = 1, Items = new[] { new UserContract() { UID = _uid } } }.ToJson());
            
            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(_uid, received.Items[0].UID, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>[] _getRangeQueryActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>("Delegate", 
                    (service, cf) =>
                    {
                        PagedCollection<UserContract> received = null;
                        service.GetRange(cf, "$filter=UID eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'", null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>("Sync", 
                    (service, cf) =>
                    {
                        return service.GetRange(cf, "$filter=UID eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'", null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetRangeAsync(cf, "$filter=UID eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'", null).Result;
                    }),
            };


        [Test]
        public void WeGetRangeUsingCompanyFileBaseUrlAndQuery([ValueSource("_getRangeQueryActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, PagedCollection<UserContract>>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/?$filter=UID eq guid'2BB63466-1A6C-4757-B3B8-D8B799D641E9'", new PagedCollection<UserContract> { Count = 1, Items = new[] { new UserContract() { UID = _uid } } }.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(_uid, received.Items[0].UID, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>[] _getByUriActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("Async", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.Get(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid.ToString().ToUpper()), null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Get(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid), null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("Async", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid), null).Result;
                    }),
            };

        [Test]
        public void WeGetByUriUsingCompanyFileBaseUrl([ValueSource("_getByUriActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid, new UserContract() { UID = _uid }.ToJson());

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(_uid, received.UID, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>[] _getByInvalidUriActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("DelegateBadCF", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.Get(cf, new Uri("http://localhost/accountright" + "/Test/User/Contract/" + _uid.ToString().ToUpper()), null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("SyncBadCF", 
                    (service, cf) =>
                    {
                        return service.Get(cf, new Uri("http://localhost/accountright" + "/Test/User/Contract/" + _uid), null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("AsyncBadCF", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, new Uri("http://localhost/accountright" + "/Test/User/Contract/" + _uid), null).Result;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("DelegateBadRoute", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.Get(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/UnexpectedRoute/" + _uid.ToString().ToUpper()), null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("SyncBadRoute", 
                    (service, cf) =>
                    {
                        return service.Get(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/UnexpectedRoute/" + _uid.ToString().ToUpper()), null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("AsyncBadRoute", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/UnexpectedRoute/" + _uid.ToString().ToUpper()), null).Result;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("DelegateInvalidUID", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.Get(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + "Item1"), null, (code, files) => { received = files; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("SyncInvalidUID", 
                    (service, cf) =>
                    {
                        return service.Get(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + "Item1"), null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>>("AsyncInvalidUID", 
                    (service, cf) =>
                    {
                        return service.GetAsync(cf, new Uri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + "Item1"), null).Result;
                    }),
            };

        [Test]
        public void WeGetByInvalidUriUsingCompanyFileBaseUrlThrowsException([ValueSource("_getByInvalidUriActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, UserContract>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid, new UserContract() { UID = _uid }.ToJson());

            // act
            var ex = Assert.Throws<ArgumentException>(() => action.Item2(_service, cf), "The test {0} should have thrown an exception", action.Item1);

        }
    }
}
