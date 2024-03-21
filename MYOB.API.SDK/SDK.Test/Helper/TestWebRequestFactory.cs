using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using MYOB.AccountRight.SDK;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;

namespace SDK.Test.Helper
{
    public class DefaultResponseTestWebRequestFactory : TestWebRequestFactory
    {
        public readonly List<Uri> UnhandledUris = new List<Uri>(); 
        
        public override WebRequest Create(Uri requestUri, string acceptEncoding = null)
        {
            var request = base.Create(requestUri, acceptEncoding);

            if (request == null)
            {
                UnhandledUris.Add(requestUri);
                request = CreateWebRequest(requestUri, () => ReturnBody(null, HttpStatusCode.BadRequest, null));
            }

            return request;
        }
    }

    public delegate void CreatedWebRequestHandler(WebRequest request); 

    public class TestWebRequestFactory : IWebRequestFactory
    {
        private readonly Dictionary<string, Func<WebResponse>> lookup = new Dictionary<string, Func<WebResponse>>();

        public event CreatedWebRequestHandler CreatedWebRequest;

        public void RegisterResultForUri(string uri, string resultBody, HttpStatusCode returnCode = HttpStatusCode.OK, string location = null)
        {
            lookup.Add(uri.TrimEnd('/').ToLowerInvariant(), () => ReturnBody(resultBody, returnCode, location));
        }

        public void RegisterResultForUri(string uri, Stream resultBody, HttpStatusCode returnCode = HttpStatusCode.OK, string location = null)
        {
            lookup.Add(uri.TrimEnd('/').ToLowerInvariant(), () => ReturnBody(resultBody, returnCode, location));
        }

        public void RegisterCompressedResultForUri(string uri, string resultBody, HttpStatusCode returnCode = HttpStatusCode.OK)
        {
            lookup.Add(uri.TrimEnd('/').ToLowerInvariant(), () => ReturnCompressedBody(resultBody, returnCode));
        }

        public void RegisterCompressedResultForUri(string uri, Stream resultBody, HttpStatusCode returnCode = HttpStatusCode.OK)
        {
            lookup.Add(uri.TrimEnd('/').ToLowerInvariant(), () => ReturnCompressedBody(resultBody, returnCode));
        }

        public void RegisterExceptionForUri<TEx>(string uri)
            where TEx : Exception, new()
        {
            lookup.Add(uri.TrimEnd('/').ToLowerInvariant(), () => { throw new TEx(); });
        }

        protected static WebResponse ReturnBody(string body, HttpStatusCode returnCode, string location)
        {
            var byteArray = Encoding.ASCII.GetBytes(body ?? string.Empty);
            return ReturnBody(new MemoryStream(byteArray), returnCode, location);
        }

        private static WebResponse ReturnBody(Stream resultBody, HttpStatusCode returnCode, string location)
        {
            var response = Substitute.For<HttpWebResponse>();
            response.GetResponseStream().Returns(resultBody);
            response.StatusCode.Returns(returnCode);
            response.Headers.Returns(location != null ? new WebHeaderCollection { { "Location", location } } : new WebHeaderCollection());
            return response;
        }

        private static WebResponse ReturnCompressedBody(string body, HttpStatusCode returnCode)
        {
            var byteArray = Encoding.ASCII.GetBytes(body);
            return ReturnCompressedBody(new MemoryStream(byteArray), returnCode);
        }

        private static WebResponse ReturnCompressedBody(Stream resultBody, HttpStatusCode returnCode)
        {
            var response = Substitute.For<HttpWebResponse>();
            var outStream = new MemoryStream();
            using (var zip = new GZipStream(outStream, CompressionMode.Compress))
            {
                resultBody.CopyTo(zip);
            }
            response.GetResponseStream().Returns(new MemoryStream(outStream.ToArray()));
            response.StatusCode.Returns(returnCode);
            response.Headers.Returns(new WebHeaderCollection() { { HttpRequestHeader.ContentEncoding, "gzip" } });
            return response;
        }

        public virtual WebRequest Create(Uri requestUri, string acceptEncoding = null)
        {
            var uri = requestUri.ToString().TrimEnd('/').ToLowerInvariant();

            if (lookup.ContainsKey(uri))
                return CreateWebRequest(new Uri(uri), lookup[uri]);

            Trace.WriteLine(string.Format("No result setup for URI {0}", uri));

            return null;
        }

        protected HttpWebRequest CreateWebRequest(Uri uri, Func<WebResponse> toReturn)
        {
            var request = Substitute.For<HttpWebRequest>();
            var asyncResult = Substitute.For<IAsyncResult>();

            request.RequestUri.Returns(uri);
            request.Headers.Returns(new WebHeaderCollection());

            request.BeginGetResponse(Arg.Any<AsyncCallback>(), Arg.Any<object>())
                   .Returns(c =>
                       {
                           asyncResult.AsyncState.Returns(c[1]);
                           c.Arg<AsyncCallback>()(asyncResult);
                           return asyncResult;
                       });

            Stream ms = new MemoryStream();

#pragma warning disable 1998
            request.GetRequestStreamAsync().Returns(async c => ms);
#pragma warning restore 1998

            request.EndGetRequestStream(Arg.Any<IAsyncResult>()).Returns(c => ms);

            request.BeginGetRequestStream(Arg.Any<AsyncCallback>(), Arg.Any<object>())
                   .Returns(c =>
                       {
                           asyncResult.AsyncState.Returns(c[1]);
                           c.Arg<AsyncCallback>()(asyncResult);
                           return asyncResult;
                       });

            request.EndGetResponse(Arg.Any<IAsyncResult>())
                   .Returns(c => toReturn());

#pragma warning disable 1998
            request.GetResponseAsync().Returns(async c => toReturn());
#pragma warning restore 1998

            if (CreatedWebRequest != null) CreatedWebRequest(request);

            return request;
        }
    }
}