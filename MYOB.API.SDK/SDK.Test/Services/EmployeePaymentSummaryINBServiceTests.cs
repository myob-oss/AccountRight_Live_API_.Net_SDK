using System;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services.Payroll;
using NUnit.Framework;
using SDK.Test.Helper;

namespace SDK.Test.Services
{
    [TestFixture]
    public class EmployeePaymentSummaryINBServiceTests
    {
        [Test]
        public void ServiceHasTheExpectedRoute()
        {
            Assert.AreEqual("Payroll/EmployeePaymentSummary/{0}/INB", new EmployeePaymentSummaryINBService(null).Route);
        }

        [Test]
        public void BuildUri_ShouldAppendSubResourceAtTheEnd()
        {
            var amendedService = new EmployeePaymentSummaryINBService(null);
            var uri = Utility.RunInstanceMethod(typeof(EmployeePaymentSummaryINBService), "BuildUri", amendedService, new object[]
            {
                new CompanyFile(){Uri = new Uri("http://localhost")},
                new Guid("e0ad9f19-8dcd-4c89-aacc-cd5e12e7ab7c"),
                null,
                null
            });
            Assert.AreEqual("http://localhost//Payroll/EmployeePaymentSummary/e0ad9f19-8dcd-4c89-aacc-cd5e12e7ab7c/INB", Convert.ToString(uri));
        }
    }
}