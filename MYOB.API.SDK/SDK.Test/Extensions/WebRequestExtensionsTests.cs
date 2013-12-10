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
        public async Task GetResponseAsync_Calls_Underlying_BeginGetResponse_AndEndGetResponse_Method()
        {
            var request = Substitute.For<WebRequest>();
            var beginGetResponseCalledEvent = new ManualResetEvent(false);
            AsyncCallback webrequestCompleteCallback = null;
            var result = Substitute.For<IAsyncResult>();

            request.BeginGetResponse(Arg.Any<AsyncCallback>(), Arg.Any<object>()).Returns(callInfo =>
                {
                    webrequestCompleteCallback = (AsyncCallback)callInfo.Args()[0];

                    beginGetResponseCalledEvent.Set();
                    return result;
                });

            var getResponseTask = request.GetResponseAsync(CancellationToken.None);

            beginGetResponseCalledEvent.WaitOne(500);

            Assert.IsNotNull(webrequestCompleteCallback, "BeginGetResponse was not called");

            webrequestCompleteCallback(result);

            await getResponseTask;

            request.Received().EndGetResponse(Arg.Any<IAsyncResult>());
        }

        [Test]
        public void Setting_CancellationToken_Calls_Underlying_Abort_Method()
        {
            var request = Substitute.For<WebRequest>();
            var beginGetResponseCalledEvent = new ManualResetEvent(false);
            AsyncCallback webrequestCompleteCallback = null;
            var result = Substitute.For<IAsyncResult>();


            request.BeginGetResponse(Arg.Any<AsyncCallback>(), Arg.Any<object>()).Returns(callInfo =>
            {
                webrequestCompleteCallback = (AsyncCallback)callInfo.Args()[0];

                beginGetResponseCalledEvent.Set();
                return result;
            });

            var cancellationSource = new CancellationTokenSource();

            var getResponseTask = request.GetResponseAsync(cancellationSource.Token);

            beginGetResponseCalledEvent.WaitOne(500);

            cancellationSource.Cancel();

            webrequestCompleteCallback(result);

            Assert.Throws<OperationCanceledException>(async () => await getResponseTask);

            request.Received().Abort();
        }

        [Test]
        public void Exceptions_Are_Converted_To_OperationCanceledExceptions_If_Cancelled()
        {
            var request = Substitute.For<WebRequest>();
            var beginGetResponseCalledEvent = new ManualResetEvent(false);
            AsyncCallback webrequestCompleteCallback = null;
            var result = Substitute.For<IAsyncResult>();

            request.BeginGetResponse(Arg.Any<AsyncCallback>(), Arg.Any<object>()).Returns(callInfo =>
            {
                webrequestCompleteCallback = (AsyncCallback)callInfo.Args()[0];

                beginGetResponseCalledEvent.Set();
                return result;
            });

            var cancellationSource = new CancellationTokenSource();

            var getResponseTask = request.GetResponseAsync(cancellationSource.Token);

            beginGetResponseCalledEvent.WaitOne(500);
            request.EndGetResponse(Arg.Any<IAsyncResult>()).Returns(_ => { throw new WebException(); });

            cancellationSource.Cancel();

            webrequestCompleteCallback(result);

            Assert.Throws(Is.InstanceOf<OperationCanceledException>(), async () => await getResponseTask);
        }

        [Test]
        public void Errors_Are_Not_Converted_To_OperationCanceledExceptions_If_Not_Cancelled()
        {
            var request = Substitute.For<WebRequest>();
            var beginGetResponseCalledEvent = new ManualResetEvent(false);
            AsyncCallback webrequestCompleteCallback = null;
            var result = Substitute.For<IAsyncResult>();

            request.BeginGetResponse(Arg.Any<AsyncCallback>(), Arg.Any<object>()).Returns(callInfo =>
            {
                webrequestCompleteCallback = (AsyncCallback)callInfo.Args()[0];

                beginGetResponseCalledEvent.Set();
                return result;
            });

            var getResponseTask = request.GetResponseAsync(CancellationToken.None);

            beginGetResponseCalledEvent.WaitOne(500);

            request.EndGetResponse(Arg.Any<IAsyncResult>()).Returns(_ => { throw new WebException(); });
            webrequestCompleteCallback(result);

            Assert.Throws<WebException>(async () => await getResponseTask);
        }
    }
}
