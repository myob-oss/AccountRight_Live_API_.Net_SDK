using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts.Version2.Inventory;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void ItemIsCreatedWithDefaultValues()
        {
            var account = new Item();

            Assert.IsTrue(account.IsActive);
        }
    }
}
