using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class JobRegisterServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("GeneralLedger/JobRegister", new JobRegisterService(null, null).Route);
        }
    }
}