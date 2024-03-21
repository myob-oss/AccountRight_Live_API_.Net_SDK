using System;
using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Contracts.Version2.Purchase;
using MYOB.AccountRight.SDK.Services;
using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class DebitRefundServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/DebitRefund", new DebitRefundService(null).Route);
        }

        [Test]
        public void UpdateSync_ThrowsNotSupportedException()
        {
            // Arrange
            var service = new DebitRefundService(null);

            // Act, Assert
            Assert.Throws<NotSupportedException>(() => service.Update(null, null, null));         
        }

        [Test]
        public void UpdateAsyncWithDelegate_ThrowsNotSupportedException()
        {
            // Arrange
            var service = new DebitRefundService(null);

            // Act, Assert
            Assert.Throws<NotSupportedException>(() => service.Update(null, null, null, null,null));
        }

        [Test]
        public void UpdateAsyncWithTask_ThrowsNotSupportedException()
        {
            // Arrange
            var service = new DebitRefundService(null);

            // Act, Assert
            Assert.Throws<NotSupportedException>(() => service.UpdateAsync(null, null, null));
        } 
    }
}