using MYOB.AccountRight.SDK;
using MYOB.AccountRight.SDK.Services.Purchase;
using NSubstitute;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class SupplierPaymentServiceTests
    {
        private IApiConfiguration _configuration;
        private IWebRequestFactory _webRequestFactory;
        private IOAuthKeyService _keyService;

        [SetUp]
        public void TestSetup()
        {
            _configuration = Substitute.For<IApiConfiguration>();
            _webRequestFactory = Substitute.For<IWebRequestFactory>();
            _keyService = Substitute.For<IOAuthKeyService>();
        }

        [Test]
        public void Route_Is_PurchaseSupplierPayment()
        {
            // Arrange
            var service = new SupplierPaymentService(_configuration, _webRequestFactory, _keyService);

            // Act
            var route = service.Route;

            // Assert
            Assert.AreEqual("Purchase/SupplierPayment", route);
        }
    }
}