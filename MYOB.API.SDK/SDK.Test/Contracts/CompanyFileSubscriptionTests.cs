using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts;
using NUnit.Framework;

namespace SDK.Test.Contracts
{
    [TestFixture]
    public class CompanyFileSubscriptionTests
    {
        [Test]
        public void CompanyFileSubscriptionDefaultValues()
        {
            var subscription = new Subscription();
            Assert.IsFalse(subscription.IsTrial);
        }
    }
}
