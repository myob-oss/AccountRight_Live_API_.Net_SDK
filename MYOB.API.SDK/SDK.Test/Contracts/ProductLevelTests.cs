using System;
using MYOB.AccountRight.SDK.Contracts;
using NUnit.Framework;

namespace SDK.Test.Contracts
{
    [TestFixture]
    public class ProductLevelTests
    {
        [Test]
        public void ProductLevelIsCreatedWithValues()
        {
            var productLevel = new ProductLevel()
                {
                    Code = 30
                };

            Assert.AreEqual(30, productLevel.Code);
            Assert.AreEqual(ProductLevelType.Plus, productLevel.Name);
        }

        [Test]
        public void ProductLevel_NameAssignmentHasNoEffect()
        {
            var productLevel = new ProductLevel()
            {
                Code = 30
            };
            productLevel.Name = ProductLevelType.Basic;

            Assert.AreEqual(30, productLevel.Code);
            Assert.AreEqual(ProductLevelType.Plus, productLevel.Name);
        }
    }

}
