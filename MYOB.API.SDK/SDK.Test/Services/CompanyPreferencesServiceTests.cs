using MYOB.AccountRight.SDK.Services.Company;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CompanyPreferencesServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company/Preferences", new CompanyPreferencesService(null).Route);
        }
    }
}
