using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK;
using NSubstitute;
using NUnit.Framework;
using MYOB.AccountRight.SDK.Extensions;

namespace SDK.Test.Extensions
{
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        private Stream GetStream(string Message)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] contentAsBytes = encoding.GetBytes(Message);
            var responseStream = new MemoryStream();
            responseStream.Write(contentAsBytes, 0, contentAsBytes.Length);
            responseStream.Position = 0;
            return responseStream; 
        }

        private WebException GetWebException(Stream responseStream )
        {
            var webResponse = Substitute.For<HttpWebResponse>();
            webResponse.GetResponseStream().Returns(responseStream);
            var wex = new WebException("test", null, WebExceptionStatus.UnknownError, webResponse);
            return wex; 
        }

        [Test]
        public void ProcessException_MessageIsString_ExceptionReturnWithoutValidErrors()
        {
            var mesg = "\"No valid errors.\"";
            using (Stream responsestream = GetStream(mesg))
            {
                var wex = GetWebException(responsestream);
                (wex.Response as HttpWebResponse).StatusCode.Returns(HttpStatusCode.BadRequest);

                var uri = new Uri("http://dc1.api.myob.com/");
                var apiCommunicationEx = Assert.Throws<ApiCommunicationException>(() => wex.ProcessException(uri));
                Assert.IsNull(apiCommunicationEx.Errors);
                Assert.AreEqual(mesg, apiCommunicationEx.ErrorInformation);
            }
        }

        [Test]
        public void ProcessException_MessageIsInvalidNumber_ExceptionReturnWithoutValidErrors()
        {
            var mesg = "ND12d345";
            
            using (Stream responsestream = GetStream(mesg))
            {
                var wex = GetWebException(responsestream);
                (wex.Response as HttpWebResponse).StatusCode.Returns(HttpStatusCode.BadRequest);

                var uri = new Uri("http://dc1.api.myob.com/");
                var apiCommunicationEx = Assert.Throws<ApiCommunicationException>(() => wex.ProcessException(uri));
                Assert.IsNull(apiCommunicationEx.Errors);
                Assert.AreEqual(mesg, apiCommunicationEx.ErrorInformation);
            }
        }

        [Test]
        public void ProcessException_ExceptionReturnWithValidErrors()
        {
            var mesg = @"{
            ""Errors"": [{                     
            ""Name"": ""ValidationError"",       
            ""Message"": ""Duplicate RequestID"",
            ""AdditionalDetails"": ""RequestID"",
            ""ErrorCode"": 16000               
            }]}";

            using (Stream responsestream = GetStream(mesg))
            {
                var wex = GetWebException(responsestream);
                (wex.Response as HttpWebResponse).StatusCode.Returns(HttpStatusCode.BadRequest);
                
                var uri = new Uri("http://dc1.api.myob.com/");
                var apiCommunicationEx = Assert.Throws<ApiCommunicationException>(() => wex.ProcessException(uri));
                Assert.IsNotNull(apiCommunicationEx.Errors[0]);
                Assert.AreEqual(16000, apiCommunicationEx.Errors[0].ErrorCode);
                Assert.AreEqual("ValidationError", apiCommunicationEx.Errors[0].Name);
                Assert.AreEqual("Duplicate RequestID", apiCommunicationEx.Errors[0].Message);
                Assert.AreEqual("RequestID", apiCommunicationEx.Errors[0].AdditionalDetails);
            }
        }
    }
}
