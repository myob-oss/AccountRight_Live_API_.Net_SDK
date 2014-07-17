using MYOB.AccountRight.SDK.Services.Company;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class FormTemplateServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company/FormTemplate", new FormTemplateService(null).Route);
        }
    }
}
