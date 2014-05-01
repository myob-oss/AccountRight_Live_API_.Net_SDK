using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Services.Version2.PayrollCategory;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class PayrollCategoryTaxTableServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/PayrollCategory/TaxTable", new PayrollCategoryTaxTableService(null, null).Route);
        }
    }
}
