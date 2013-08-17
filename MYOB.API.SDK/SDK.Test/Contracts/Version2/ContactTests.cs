using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void AccountIsCreatedWithDefaultValues()
        {
            var contact = new Contact();

            Assert.IsTrue(contact.IsActive);
        }
    }
}