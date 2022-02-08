using MYOB.AccountRight.SDK.Services.Company;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CustomListServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company/CustomList", new CustomListService(null).Route);
        }
    }
}
