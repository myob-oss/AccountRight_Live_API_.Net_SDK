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
        public class TestMutableService : MutableService<UserContract>
        {
            public TestMutableService(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService) : base(configuration, webRequestFactory, keyService)
            {
            }

            public override string Route
            {
                get { return "Test/User/Contract"; }
            }
        }

        private IApiConfiguration _configuration;
        private DefaultResponseTestWebRequestFactory _webFactory;
        private TestMutableService _service;
        private static Guid _uid;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _configuration.GenerateUris.Returns(true);

            _webFactory = new DefaultResponseTestWebRequestFactory();
            _service = new TestMutableService(_configuration, _webFactory, null);
            _configuration.ApiBaseUrl.Returns(ApiRequestHandler.ApiRequestUri.AbsoluteUri);
            _uid = Guid.NewGuid();
        }

        private readonly Tuple<string, Func<TestMutableService, CompanyFile, bool>>[] _deleteActions = new[]
            {
                new Tuple<string, Func<TestMutableService, CompanyFile, bool>>("Delegate", 
                    (service, cf) =>
                    {
                        var ret = false;
                        service.Delete(cf, _uid, null, (code) => { ret = true; }, (uri, exception) => Assert.Fail(exception.Message));
                        return ret;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, bool>>("Sync", 
                    (service, cf) =>
                    {
                        service.Delete(cf, _uid, null);
                        return true;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, bool>>("Async", 
                    (service, cf) =>
                    {
                        service.DeleteAsync(cf, _uid, null);
                        return true;
                    }),
                 new Tuple<string, Func<TestMutableService, CompanyFile, bool>>("Async2", 
                    (service, cf) =>
                    {
                        service.DeleteAsync(cf, _uid, null, CancellationToken.None);
                        return true;
                    }),
            };


        [Test]
        public void WeDeleteContactUsingCompanyFileBaseUrl([ValueSource("_deleteActions")] Tuple<string, Func<TestMutableService, CompanyFile, bool>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + _uid, (string) null);

            // act
            var ret = action.Item2(_service, cf);

            // assert
            Assert.IsTrue(ret, "Incorrect data received during {0} operation", action.Item1);
        }

        private readonly Tuple<string, Func<TestMutableService, CompanyFile, string>>[] _postActions = new[]
            {
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Insert(cf, new UserContract() {UID = UID}, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Insert(cf, new UserContract() {UID = UID}, null);
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.InsertAsync(cf, new UserContract() {UID = UID}, null).Result;
                    }),
                 new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Async2", 
                    (service, cf) =>
                    {
                        return service.InsertAsync(cf, new UserContract() {UID = UID}, null, CancellationToken.None).Result;
                    }),
            };


        [Test]
        public void WePostContactUsingCompanyFileBaseUrl([ValueSource("_postActions")] Tuple<string, Func<TestMutableService, CompanyFile, string>> action)
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

        private readonly Tuple<string, Func<TestMutableService, CompanyFile, string>>[] _putActions = new[]
            {
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Delegate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new UserContract() { UID = UID }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Sync", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new UserContract() { UID = UID }, null);
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new UserContract() { UID = UID }, null).Result;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("Async2", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new UserContract() { UID = UID }, null, CancellationToken.None).Result;
                    }),
            };

        [Test]
        public void WePutContactUsingCompanyFileBaseUrl([ValueSource("_putActions")] Tuple<string, Func<TestMutableService, CompanyFile, string>> action)
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

        private readonly Tuple<string, Func<TestMutableService, CompanyFile, string>>[] _errorLevelActions = new[]
            {
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("DelegateUpdate", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Update(cf, new UserContract() { UID = UID }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message), ErrorLevel.WarningsAsErrors);
                        return received;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("SyncUpdate", 
                    (service, cf) =>
                    {
                        return service.Update(cf, new UserContract() { UID = UID }, null, ErrorLevel.WarningsAsErrors);
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("AsyncUpdate", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new UserContract() { UID = UID }, null, ErrorLevel.WarningsAsErrors).Result;
                    }),
                 new Tuple<string, Func<TestMutableService, CompanyFile, string>>("AsyncUpdate2", 
                    (service, cf) =>
                    {
                        return service.UpdateAsync(cf, new UserContract() { UID = UID }, null, CancellationToken.None, ErrorLevel.WarningsAsErrors).Result;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("DelegateInsert", 
                    (service, cf) =>
                    {
                        string received = null;
                        service.Insert(cf, new UserContract() { UID = UID }, null, (code, location) => { received = location; }, (uri, exception) => Assert.Fail(exception.Message), ErrorLevel.WarningsAsErrors);
                        return received;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("SyncInsert", 
                    (service, cf) =>
                    {
                        return service.Insert(cf, new UserContract() { UID = UID }, null, ErrorLevel.WarningsAsErrors);
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("AsyncInsert", 
                    (service, cf) =>
                    {
                        return service.InsertAsync(cf, new UserContract() { UID = UID }, null, ErrorLevel.WarningsAsErrors).Result;
                    }),
                 new Tuple<string, Func<TestMutableService, CompanyFile, string>>("AsyncInsert2", 
                    (service, cf) =>
                    {
                        return service.InsertAsync(cf, new UserContract() { UID = UID }, null, CancellationToken.None, ErrorLevel.WarningsAsErrors).Result;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("DelegateDelete", 
                    (service, cf) =>
                    {
#pragma warning disable 219
                        var ret = false;
#pragma warning restore 219
                        service.Delete(cf, _uid, null, (code) => { ret = true; }, (uri, exception) => Assert.Fail(exception.Message), ErrorLevel.WarningsAsErrors);
                        return string.Empty;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("SyncDelete", 
                    (service, cf) =>
                    {
                        service.Delete(cf, _uid, null, ErrorLevel.WarningsAsErrors);
                        return string.Empty;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("AsyncDelete", 
                    (service, cf) =>
                    {
                        service.DeleteAsync(cf, _uid, null, ErrorLevel.WarningsAsErrors);
                        return string.Empty;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, string>>("AsyncDelete2", 
                    (service, cf) =>
                    {
                        service.DeleteAsync(cf, _uid, null, CancellationToken.None, ErrorLevel.WarningsAsErrors);
                        return string.Empty;
                    }),
            };

        [Test]
        public void QueryString_Has_WarningsAsErrors_When_ErrorLevel_Is_Supplied([ValueSource("_errorLevelActions")] Tuple<string, Func<TestMutableService, CompanyFile, string>> action)
        {
            // arrange
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(_webFactory.UnhandledUris.First(u => u.Query.ToLower().Contains("warningsaserrors=true")));
            Assert.IsNull(_webFactory.UnhandledUris.FirstOrDefault(u => u.Query.ToLower().Contains("generateuris=false")));
        }

        [Test]
        public void QueryString_Has_GenerateUris_When_ConfigurationSettingIsSet([ValueSource("_errorLevelActions")] Tuple<string, Func<TestMutableService, CompanyFile, string>> action)
        {
            // arrange
            _configuration.GenerateUris.Returns(false);
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(_webFactory.UnhandledUris.First(u => u.Query.ToLower().Contains("generateuris=false")));
        }

        private readonly Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>[] _postActionsEx = new[]
            {
                new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Delegate", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.InsertEx(cf, new UserContract() { UID = UID }, null, (code, location, entity) => { received = entity; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Sync", 
                    (service, cf) =>
                    {
                        return service.InsertEx(cf, new UserContract() {UID = UID}, null);
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Async", 
                    (service, cf) =>
                    {
                        return service.InsertExAsync(cf, new UserContract() {UID = UID}, null).Result;
                    }),
                 new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Async2", 
                    (service, cf) =>
                    {
                        return service.InsertExAsync(cf, new UserContract() {UID = UID}, null, CancellationToken.None).Result;
                    }),
            };

        [Test]
        public void BodyIsReturned_AfterInsertOperation([ValueSource("_postActionsEx")] Tuple<string, Func<TestMutableService, CompanyFile, UserContract>> action)
        {
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID;
            var entity = new UserContract() { UID = UID };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/?returnbody=true", entity.ToJson(), HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(received, "Incorrect data received during {0} operation", action.Item1);
            Assert.AreEqual(entity.UID, received.UID);
        }

        private readonly Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>[] _putActionsEx = new[]
            {
                new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Delegate", 
                    (service, cf) =>
                    {
                        UserContract received = null;
                        service.UpdateEx(cf, new UserContract() { UID = UID }, null, (code, location, entity) => { received = entity; }, (uri, exception) => Assert.Fail(exception.Message));
                        return received;
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Sync", 
                    (service, cf) =>
                    {
                        return service.UpdateEx(cf, new UserContract() { UID = UID }, null);
                    }),
                new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Async", 
                    (service, cf) =>
                    {
                        return service.UpdateExAsync(cf, new UserContract() { UID = UID }, null).Result;
                    }),
                 new Tuple<string, Func<TestMutableService, CompanyFile, UserContract>>("Async2", 
                    (service, cf) =>
                    {
                        return service.UpdateExAsync(cf, new UserContract() { UID = UID }, null, CancellationToken.None).Result;
                    }),
            };

        [Test]
        public void BodyIsReturned_AfterUpdateOperation([ValueSource("_putActionsEx")] Tuple<string, Func<TestMutableService, CompanyFile, UserContract>> action)
        {
            var cf = new CompanyFile() { Uri = new Uri("https://dc1.api.myob.com/accountright/7D5F5516-AF68-4C5B-844A-3F054E00DF10") };
            var location = cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID;
            var entity = new UserContract() { UID = UID };
            _webFactory.RegisterResultForUri(cf.Uri.AbsoluteUri + "/Test/User/Contract/" + UID + "?returnbody=true", entity.ToJson(), HttpStatusCode.OK, location);

            // act
            var received = action.Item2(_service, cf);

            // assert
            Assert.IsNotNull(received, "Incorrect data received during {0} operation", action.Item1);
            Assert.AreEqual(entity.UID, received.UID);
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

            public override Task<string> UpdateAsync(CompanyFile cf, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
            {
                return UpdateAsyncCallback(cf, entity, credentials, errorLevel, cancellationToken);
            }

            public override Task DeleteAsync(CompanyFile cf, Guid uid, ICompanyFileCredentials credentials, CancellationToken cancellationToken, ErrorLevel errorLevel = ErrorLevel.IgnoreWarnings)
            {
                return DeleteAsyncCallback(cf, uid, credentials, errorLevel, cancellationToken);
            }

            public override string Route
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
