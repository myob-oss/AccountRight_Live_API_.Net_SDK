using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using NUnit.Framework;

namespace SDK.Test.Contracts.Version2
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AccountIsCreatedWithDefaultValues()
        {
            var category = new Category();

            Assert.IsTrue(category.IsActive);
        }
    }
}