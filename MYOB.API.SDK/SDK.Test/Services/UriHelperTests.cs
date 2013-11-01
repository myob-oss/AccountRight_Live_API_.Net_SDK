using System;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Services;
using NUnit.Framework;

namespace SDK.Test.Services
{
    [TestFixture]
    public class UriHelperTests
    {
        private CompanyFile _companyFile;
        private string _route;
        [SetUp]
        public void Setup()
        {
            _companyFile = new CompanyFile { 
                Id = Guid.NewGuid(),
            };
            _companyFile.Uri = new Uri("https://api.myob.com/accountright/" + _companyFile.Id);
            _route = "route";
        }
        [Test]
        public void BuildUri_With_RouteOnly_Return_Uri()
        {
            // arrange

            // act
            var result = UriHelper.BuildUri(_companyFile, _route);

            // assert
            var expectedUri = string.Format("https://api.myob.com/accountright/{0}/{1}/", _companyFile.Id, _route);
            Assert.AreEqual(expectedUri, result.ToString());
        }


        [Test]
        public void BuildUri_With_RouteAndUid_Return_Uri()
        {
            // arrange
            var uid = Guid.NewGuid();

            // act
            var result = UriHelper.BuildUri(_companyFile, _route, uid);

            // assert
            var expectedUri = string.Format("https://api.myob.com/accountright/{0}/{1}/{2}", _companyFile.Id, _route, uid);
            Assert.AreEqual(expectedUri, result.ToString());
        }

        [Test]
        public void BuildUri_With_RouteAndUid_AndPostResource_Return_Uri()
        {
            // arrange
            var uid = Guid.NewGuid();
            const string postResource = "?$filter=Name eq 'abc'";

            // act
            var result = UriHelper.BuildUri(_companyFile, _route, uid, postResource);

            // assert
            var expectedUri = string.Format("https://api.myob.com/accountright/{0}/{1}/{2}?$filter=Name eq 'abc'", _companyFile.Id, _route, uid);
            Assert.AreEqual(expectedUri, result.ToString());
        }
    }
}
