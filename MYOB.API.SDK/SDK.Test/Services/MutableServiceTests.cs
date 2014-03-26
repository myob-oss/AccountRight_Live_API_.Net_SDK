using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    using System.Threading;

    [TestFixture]
    public class MutableServiceTests
    {
        public class TestReadOnlyService : MutableService<UserContract>
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

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>[] _deleteActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>("Delegate", 
                    (service, cf) =>
                    {
                        var ret = false;
                        service.Delete(cf, _uid, null, (code) => { ret = true; }, (uri, exception) => Assert.Fail(exception.Message));
                        return ret;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>("Sync", 
                    (service, cf) =>
                    {
                        service.Delete(cf, _uid, null);
                        return true;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>>("Async", 
                    (service, cf) =>
                    {
                        service.DeleteAsync(cf, _uid, null);
                        return true;
                    }),
            };


        [Test]
        public void WeDeleteContactUsingCompanyFileBaseUrl([ValueSource("_deleteActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, bool>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid, (string) null);

            // act
            var ret = action.Item2(_service, cf);

            // assert
            Assert.IsTrue(ret, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>[] _postActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Insert(cf, new UserContract() {UID = UID}, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Insert(cf, new UserContract() {UID = UID}, null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.InsertAsync(cf, new UserContract() {UID = UID}, null).Result;
                    }),
            };


        [Test]
        public void WePostContactUsingCompanyFileBaseUrl([ValueSource("_postActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract", (string) null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }

        protected static Guid UID = Guid.NewGuid();

        private readonly Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>[] _putActions = new[]
            {
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new UserContract() { UID = UID }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new UserContract() { UID = UID }, null);
                    }),
                new Tuple<string, Func<TestReadOnlyService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new UserContract() { UID = UID }, null).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl([ValueSource("_putActions")] Tuple<string, Func<TestReadOnlyService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID;
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID, (string) null, HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.AreEqual(location, received, "Incorrect data received during {0} operation", action.Item1);
        }

        [Test]
        public void UpdateAsync_Overloads_Call_Through_Correctly()
        {
            var cf = new CompanyFile();
            var baseEntity = Substitute.For<BaseEntity>();
            var credentials = Substitute.For<ICompanyFileCredentials>();
            var errorLevel = ErrorLevel.WarningsAsErrors;
            var ret = Task.FromResult("");

            var callCount = 0;

            var testMutableService = new MutableServiceTestClass<BaseEntity>(Substitute.For<IApiConfiguration>(), Substitute.For<IWebRequestFactory>(), Substitute.For<IOAuthKeyService>())
            {
                UpdateAsyncCallback =

                    (_cf, _entity, _credentials, _errorLevel, _cancellationToken) =>
                        {
                            callCount++;
                            Assert.AreEqual(cf, _cf);
                            Assert.AreEqual(baseEntity, _entity);
                            Assert.AreEqual(errorLevel, _errorLevel);
                            Assert.AreEqual(_cancellationToken, CancellationToken.None);

                            return ret;
                        }
            };


            var _ret = testMutableService.UpdateAsync(cf, baseEntity, credentials, errorLevel);

            Assert.AreEqual(1, callCount);
            Assert.AreEqual(_ret, ret);
        }

        [Test]
        public void DeleteAsync_Overloads_Call_Through_Correctly()
        {
            var cf = new CompanyFile();
            var id = Guid.NewGuid();
            var credentials = Substitute.For<ICompanyFileCredentials>();
            var errorLevel = ErrorLevel.WarningsAsErrors;
            var ret = Task.FromResult("");

            var callCount = 0;

            var testMutableService = new MutableServiceTestClass<BaseEntity>(Substitute.For<IApiConfiguration>(), Substitute.For<IWebRequestFactory>(), Substitute.For<IOAuthKeyService>())
            {
                DeleteAsyncCallback =

                    (_cf, _id, _credentials, _errorLevel, _cancellationToken) =>
                    {
                        callCount++;
                        Assert.AreEqual(cf, _cf);
                        Assert.AreEqual(id, _id);
                        Assert.AreEqual(errorLevel, _errorLevel);
                        Assert.AreEqual(_cancellationToken, CancellationToken.None);

                        return ret;
                    }
            };


            var _ret = testMutableService.DeleteAsync(cf, id, credentials, errorLevel);

            Assert.AreEqual(1, callCount);
            Assert.AreEqual(_ret, ret);
        }

        private class MutableServiceTestClass<T> : MutableService<T>
            where T : BaseEntity
        {
            public Func<CompanyFile, T, ICompanyFileCredentials, ErrorLevel, CancellationToken, Task<string>> UpdateAsyncCallback { get;set; }

            public Func<CompanyFile, Guid, ICompanyFileCredentials, ErrorLevel, CancellationToken, Task<string>> DeleteAsyncCallback { get; set; }


            public MutableServiceTestClass(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService)
                : base(configuration, webRequestFactory, keyService)
            {
            }

            public override Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, ErrorLevel errorLevel, CancellationToken cancellationToken)
            {
                return UpdateAsyncCallback(cf, entity, credentials, errorLevel, cancellationToken);
            }

            public override Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, ErrorLevel errorLevel, CancellationToken cancellationToken)
            {
                return DeleteAsyncCallback(cf, uid, credentials, errorLevel, cancellationToken);
            }

            internal override string Route
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
