using MYOB.AccountRight.SDK.Services.Security;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class RoleServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Security/Role", new RoleService(null, null).Route);
        }
    }
}