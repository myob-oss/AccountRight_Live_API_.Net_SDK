using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CurrentUserServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("CurrentUser", new CurrentUserService(null, null).Route);
        }
    }
}
