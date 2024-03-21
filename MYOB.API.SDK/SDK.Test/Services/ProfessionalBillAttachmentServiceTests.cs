using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;
using System;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ProfessionalBillAttachmentServiceTests
    {
        [Test]
        public void ServiceHasExpectedRoute()
        {
            Assert.AreEqual("/Purchase/Bill/Professional/{uid}/Attachment", new ProfessionalBillAttachmentService(null, null).Route);
        }

        [Test]
        public void When_NoAttachmentUIDProvided_ServiceBuildsURICorrectly()
        {
            var service = new ProfessionalBillAttachmentService(null, null);
            var expected = new Uri("http://api.test.com/accountright/Purchase/Bill/Professional/7c54adeb-ec94-493e-8317-f2c893ecadfc/Attachment");

            var cf = new CompanyFile
            {
                Uri = new Uri("http://api.test.com/accountright")
            };
            var billUid = new Guid("7c54adeb-ec94-493e-8317-f2c893ecadfc");

            var actual = service.BuildUri(cf, billUid, null, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_AttachmentUIDProvided_ServiceBuildsURICorrectly()
        {
            var service = new ProfessionalBillAttachmentService(null, null);
            var expected = new Uri("http://api.test.com/accountright/Purchase/Bill/Professional/7c54adeb-ec94-493e-8317-f2c893ecadfc/Attachment/ae625ae8-96fd-4f5d-8c66-d6de2e2c96e3");

            var cf = new CompanyFile
            {
                Uri = new Uri("http://api.test.com/accountright")
            };
            var billUid = new Guid("7c54adeb-ec94-493e-8317-f2c893ecadfc");
            var attachmentUid = new Guid("ae625ae8-96fd-4f5d-8c66-d6de2e2c96e3");

            var actual = service.BuildUri(cf, billUid, attachmentUid, null);
            Assert.AreEqual(expected, actual);
        }
    }
}
