using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class BillAttachmentWrapperTests
    {
        [Test]
        public void BillAttachmentIsCreatedWithDefaultValues()
        {
            var billAttachment = new BillAttachmentWrapper();

            Assert.AreEqual(billAttachment.Attachments, null);
        }
    }
}
