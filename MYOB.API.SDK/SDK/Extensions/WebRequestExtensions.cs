#if ASYNC

using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MYOB.AccountRight.SDK.Extensions
{
    internal static class WebRequestExtensions
    {
        public static async Task<HttpWebResponse> GetResponseAsync(this WebRequest request, CancellationToken cancellationToken)
        {
            using (cancellationToken.Register(request.Abort, false))
            {
                try
                {
                    var response = await request.GetResponseAsync();
                    cancellationToken.ThrowIfCancellationRequested();
                    return (HttpWebResponse)response;
                }
                catch (WebException ex)
                {
                    if (cancellationToken.IsCancellationRequested)
                        throw new TaskCanceledException(ex.Message, ex);

                    throw;
                }
            }
        }
    }
}

#endif