using MYOB.AccountRight.SDK.Services.Purchase;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class ItemBillServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/Bill/Item", new ItemBillService(null).Route);
        }
    }

    [TestFixture]
    public class MiscellaneousBillServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/Bill/Miscellaneous", new MiscellaneousBillService(null).Route);
        }
    }

    [TestFixture]
    public class ProfessionalBillServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/Bill/Professional", new ProfessionalBillService(null).Route);
        }
    }

    [TestFixture]
    public class ServiceBillServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Purchase/Bill/Service", new ServiceBillService(null).Route);
        }
    }
}
