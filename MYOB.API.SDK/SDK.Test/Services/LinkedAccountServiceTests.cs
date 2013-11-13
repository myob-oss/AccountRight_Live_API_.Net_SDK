using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class LinkedAccountServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/LinkedAccount", new LinkedAccountService(null, null).Route);
        }

        [Test]
        public void DeleteSyncIsNotSupported()
        {
            var service = new LinkedAccountService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Delete(null, Guid.Empty, null));
        }

        [Test]
        public void DeleteDelegateIsNotSupported()
        {
            var service = new LinkedAccountService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Delete(null, Guid.Empty, null, (code) => { }, (uri, exception) => { }));
        }

        [Test]
        public void DeleteAsyncIsNotSupported()
        {
            var service = new LinkedAccountService(null, null);

            Assert.Throws<NotSupportedException>(() => service.DeleteAsync(null, Guid.Empty, null).Wait());
        }

        [Test]
        public void InsertSyncIsNotSupported()
        {
            var service = new LinkedAccountService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Insert(null,new LinkedAccount(), null));
        }

        [Test]
        public void InsertDelegateIsNotSupported()
        {
            var service = new LinkedAccountService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Insert(null, new LinkedAccount(), null, (code, s) => { }, (uri, exception) => { }));
        }

        [Test]
        public void InsertAsyncIsNotSupported()
        {
            var service = new LinkedAccountService(null, null);

            Assert.Throws<NotSupportedException>(() => service.InsertAsync(null, new LinkedAccount(), null).Wait());
        }
    }
}