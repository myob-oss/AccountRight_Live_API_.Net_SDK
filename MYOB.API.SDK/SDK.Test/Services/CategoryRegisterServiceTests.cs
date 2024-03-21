using System;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CategoryRegisterServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/CategoryRegister", new CategoryRegisterService(null, null).Route);
        }
        
        [Test]
        public void Get_UID_SyncIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Get(null, Guid.Empty, null));
        }

        [Test]
        public void Get_UID_DelegateIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Get(null, Guid.Empty, null, (code, s) => { }, (uri, exception) => { }));
        }

        [Test]
        public void Get_UID_AsyncIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            var ex = Assert.Throws<AggregateException>(() => service.GetAsync(null, Guid.Empty, null).Wait());
            Assert.IsInstanceOf<NotSupportedException>(ex.InnerException);
        }

        [Test]
        public void Get_URI_SyncIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Get(null, null, null));
        }

        [Test]
        public void Get_URI_DelegateIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Get(null, null, null, (code, s) => { }, (uri, exception) => { }));
        }

        [Test]
        public void Get_URI_AsyncIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            var ex = Assert.Throws<AggregateException>(() => service.GetAsync(null, null, null).Wait());
            Assert.IsInstanceOf<NotSupportedException>(ex.InnerException);
        }
    }
}