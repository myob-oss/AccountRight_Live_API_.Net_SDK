using System;
using System.IO;
using System.Net;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

#if ASYNC
using System.Threading.Tasks;
using System.Threading;
#endif

namespace MYOB.AccountRight.SDK.Communication
{
    internal class ApiStreamRequestHandler
    {
        private const string LocationHeader = "Location";

        protected class RequestContext
        {
            public WebRequest Request { get; set; }
            public string Body { get; set; }
            public Action<HttpStatusCode, string, Stream> OnComplete { get; set; }
            public Action<Uri, Exception> OnError { get; set; }
        }

        private readonly OAuthTokens _oauth;
        private readonly IApiConfiguration _configuration;
        private readonly ICompanyFileCredentials _credentials;
        private readonly ApiRequestHelper _helper;

        public ApiStreamRequestHandler(IApiConfiguration configuration, ICompanyFileCredentials credentials, OAuthTokens oauth = null)
        {
            _oauth = oauth;
            _configuration = configuration;
            _credentials = credentials;
            _helper = new ApiRequestHelper();
        }

        public void Get(WebRequest request, Action<HttpStatusCode, Stream> onComplete, Action<Uri, Exception> onError)
        {
            SetStandardHeaders(request);
            request.BeginGetResponse(HandleResponseCallback,
                                     new RequestContext
                                         {
                                             Request = request,
                                             OnComplete = (code, s, entity) => onComplete(code, entity),
                                             OnError = onError,
                                         });
        }

#if ASYNC
        async public Task<Tuple<HttpStatusCode, Stream>> GetAsync(WebRequest request, CancellationToken cancellationToken)
        {
            SetStandardHeaders(request);
            var get = await GetResponseTask(request, cancellationToken);
            return new Tuple<HttpStatusCode, Stream>(get.Item1, get.Item3);
        }
#endif

        private void SetStandardHeaders(WebRequest request)
        {
            _helper.SetStandardHeaders(request, _configuration, _credentials, _oauth);
        }

#if ASYNC
        protected async Task<Tuple<HttpStatusCode, string, Stream>> GetResponseTask(WebRequest request, CancellationToken cancellationToken)
        {
            var response = await request.GetResponseAsync(cancellationToken);
            var location = response.Headers[LocationHeader];
            var statusCode = (response as HttpWebResponse).Maybe(_ => _.StatusCode);
            if (_helper.IsGZipped((HttpWebResponse)response))
            {
                var entityCompressed = _helper.ExtractCompressedEntity(response);
                return new Tuple<HttpStatusCode, string, Stream>(statusCode, location, entityCompressed);
            }
            var entityNormal = response.GetResponseStream();
            return new Tuple<HttpStatusCode, string, Stream>(statusCode, location, entityNormal);
        }
#endif

        protected void HandleResponseCallback(IAsyncResult asynchronousResult)
        {
            var requestData = (RequestContext)asynchronousResult.AsyncState;
            var request = requestData.Request;
            var uri = request.RequestUri;

            try
            {
                var response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                var location = response.Headers[LocationHeader];

                var stream = _helper.IsGZipped(response) ? _helper.ExtractCompressedEntity(response) : response.GetResponseStream();
                requestData.OnComplete(response.StatusCode, location, stream);
            }
            catch (Exception ex)
            {
                requestData.OnError(uri, ex);
            }
        }
    }
}
