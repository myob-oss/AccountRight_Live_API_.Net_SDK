using System;
using System.Collections.Generic;
using System.Linq;
using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class NamespaceTests
    {
        private static IEnumerable<Type> ServiceTypes
        {
            get
            {
                var baseType = typeof (ServiceBase);
                return baseType.Assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
            }
        }


        [Test]
        public void AllServicesMustExistInTheCorrectNamespace([ValueSource("ServiceTypes")]Type serviceType)
        {
            Assert.IsTrue(serviceType.Namespace.StartsWith(typeof(ServiceBase).Namespace));
            Assert.IsFalse(serviceType.Namespace.Contains("Version2"));
        }
    }
}
