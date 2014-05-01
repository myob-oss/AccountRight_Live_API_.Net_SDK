using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Services.Version2.Banking;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class StatementServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Banking/Statement", new StatementService(null, null, null).Route);
        }
    }
}
