using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class CompanyServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Company", new CompanyService(null, null).Route);
        }
    }
}
