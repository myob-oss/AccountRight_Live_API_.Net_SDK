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
        public void GetSyncIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Get(null, Guid.Empty, null));
        }

        [Test]
        public void GetAsyncIsNotSupported()
        {
            var service = new CategoryRegisterService(null, null);

            Assert.Throws<NotSupportedException>(() => service.Get(null, Guid.Empty, null, (code, s) => { }, (uri, exception) => { }));
        }
    }
}