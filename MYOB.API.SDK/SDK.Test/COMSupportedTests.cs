using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test
{
    [TestFixture]
    public class COMSupportedTests
    {
        [Test]
        public void AssemblySupportsCOM()
        {
            var attribute = (ComVisibleAttribute)typeof(Account).Assembly.GetCustomAttributes(typeof(ComVisibleAttribute), true).FirstOrDefault();

            Assert.NotNull(attribute);
            Assert.IsTrue(attribute.Value);
        }
    }
}
