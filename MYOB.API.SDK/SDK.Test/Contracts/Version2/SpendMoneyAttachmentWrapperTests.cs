using MYOB.AccountRight.SDK.Contracts.Version2.Banking;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class SpendMoneyAttachmentWrapperTests
    {
        [Test]
        public void SMAttachmentIsCreatedWithDefaultValues()
        {
            var smAttachment = new SpendMoneyAttachmentWrapper();

            Assert.AreEqual(smAttachment.Attachments, null);
        }
    }
}
