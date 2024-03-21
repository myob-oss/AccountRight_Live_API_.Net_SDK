using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using NUnit.Framework;

namespace SDK.Test
{
    [TestFixture]
    public class ApiCommunicationExceptionTests
    {
        [Test]
        public void CanCorrectlyDeserializeASerializedException()
        {
            // arrange
            var exception = new ApiCommunicationException("Message", HttpStatusCode.Ambiguous,
                new Uri("http://localhost:9000"), null, new[] { new Error() { AdditionalDetails = "AdditionalDetails" } }, "Information", Guid.NewGuid().ToString());

            // act
            var formatter = new BinaryFormatter();
            ApiCommunicationException deserialized;
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, exception);
                stream.Seek(0, SeekOrigin.Begin);
                deserialized = (ApiCommunicationException)formatter.Deserialize(stream);
            }

            // assert
            Assert.AreNotEqual(exception, deserialized);
            Assert.AreEqual(exception.StatusCode, deserialized.StatusCode);
            Assert.AreEqual(exception.ErrorInformation, deserialized.ErrorInformation);
            Assert.AreEqual(exception.URI, deserialized.URI);
            Assert.AreEqual(exception.RequestId, deserialized.RequestId);
            Assert.AreEqual(exception.Errors.Count, deserialized.Errors.Count);
            Assert.AreEqual(exception.Errors[0].AdditionalDetails, deserialized.Errors[0].AdditionalDetails);
        }
    }
}
