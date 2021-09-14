using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services.Banking;
using NUnit.Framework;
using System;

namespace SDK.Test.Services
{
    [TestFixture]
    public class SpendMoneyAttachmentServiceTests
    {
        [Test]
        public void ServiceHasExpectedRoute()
        {
            Assert.AreEqual("Banking/SpendMoney/{uid}/Attachment", new SpendMoneyAttachmentService(null, null).Route);
        }

        [Test]
        public void When_NoAttachmentUIDProvided_ServiceBuildsURICorrectly()
        {
            var service = new SpendMoneyAttachmentService(null, null);
            var expected = new Uri("http://api.test.com/accountright/Banking/SpendMoney/7c54adeb-ec94-493e-8317-f2c893ecadfc/Attachment");

            var cf = new CompanyFile
            {
                Uri = new Uri("http://api.test.com/accountright")
            };
            var spendMoneyUid = new Guid("7c54adeb-ec94-493e-8317-f2c893ecadfc");

            var actual = service.BuildUri(cf, spendMoneyUid, null, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_AttachmentUIDProvided_ServiceBuildsURICorrectly()
        {
            var service = new SpendMoneyAttachmentService(null, null);
            var expected = new Uri("http://api.test.com/accountright/Banking/SpendMoney/7c54adeb-ec94-493e-8317-f2c893ecadfc/Attachment/ae625ae8-96fd-4f5d-8c66-d6de2e2c96e3");

            var cf = new CompanyFile
            {
                Uri = new Uri("http://api.test.com/accountright")
            };
            var spendMoneyUid = new Guid("7c54adeb-ec94-493e-8317-f2c893ecadfc");
            var attachmentUid = new Guid("ae625ae8-96fd-4f5d-8c66-d6de2e2c96e3");

            var actual = service.BuildUri(cf, spendMoneyUid, attachmentUid, null);
            Assert.AreEqual(expected, actual);
        }
    }
}
