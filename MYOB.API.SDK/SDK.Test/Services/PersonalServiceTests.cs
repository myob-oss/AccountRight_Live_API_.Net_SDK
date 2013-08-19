using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Contact;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PersonalServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Contact/Personal", new PersonalService(null, null).Route);
        }
    }
}