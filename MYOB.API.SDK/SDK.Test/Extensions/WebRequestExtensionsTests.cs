using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using System.Threading;

using MYOB.AccountRight.SDK.Extensions;

using NSubstitute;

namespace SDK.Test.Extensions
{
    [TestFixture]
    public class WebRequestExtensionsTests
    {
        [Test]
        public async Task GetResponseAsync_Calls_Underlying_GetResponseAsyncMethod()
        {
            var request = Substitute.For<WebRequest>();

            request.GetResponseAsync(CancellationToken.None);

            request.Received().GetResponseAsync();
        }

        [Test]
        public void Setting_CancellationToken_Calls_Underlying_Abort_Method()
        {
            var request = Substitute.For<WebRequest>();
            var webRequestCompleteEvent = new ManualResetEvent(false);

            request.GetResponseAsync().Returns(c => Task.Run(() =>
                {
                    webRequestCompleteEvent.WaitOne(5000);


                    return (WebResponse)null;
                }));

            var cancellationSource = new CancellationTokenSource();

            var getResponseTask = request.GetResponseAsync(cancellationSource.Token);

            cancellationSource.Cancel();

            webRequestCompleteEvent.Set();

            Assert.Throws<OperationCanceledException>(async () => await getResponseTask);

            request.Received().Abort();
        }

        [Test]
        public void Exceptions_Are_Converted_To_OperationCanceledExceptions_If_Cancelled()
        {
            var request = Substitute.For<WebRequest>();
            var webRequestCompleteEvent = new ManualResetEvent(false);

            request.GetResponseAsync().Returns(c => Task.Run(() =>
            {
                webRequestCompleteEvent.WaitOne(5000);

                throw new WebException();

                return (WebResponse)null;
            }));

            var cancellationSource = new CancellationTokenSource();

            var getResponseTask = request.GetResponseAsync(cancellationSource.Token);

            cancellationSource.Cancel();

            webRequestCompleteEvent.Set();

            Assert.Throws(Is.InstanceOf<OperationCanceledException>(), async () => await getResponseTask);
        }

        [Test]
        public void Errors_Are_Not_Converted_To_OperationCanceledExceptions_If_Not_Cancelled()
        {
            var request = Substitute.For<WebRequest>();
            var beginGetResponseCalledEvent = new ManualResetEvent(false);
            var webRequestCompleteEvent = new ManualResetEvent(false);

            request.GetResponseAsync().Returns(c => Task.Run(() =>
            {
                beginGetResponseCalledEvent.Set();
                webRequestCompleteEvent.WaitOne(500);

                throw new WebException();

                return (WebResponse)null;
            }));

            var getResponseTask = request.GetResponseAsync(CancellationToken.None);

            beginGetResponseCalledEvent.WaitOne(500);

            webRequestCompleteEvent.Set();

            Assert.Throws<WebException>(async () => await getResponseTask);
        }
    }
}
