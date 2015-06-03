using MYOB.AccountRight.SDK.Services.Security;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Security/User", new UserService(null, null).Route);
        }
    }
}