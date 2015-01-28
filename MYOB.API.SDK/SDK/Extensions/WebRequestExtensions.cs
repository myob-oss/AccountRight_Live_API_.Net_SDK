#if ASYNC

using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MYOB.AccountRight.SDK.Extensions
{
    /// <summary>
    /// Extensions that improve webrequest handling
    /// </summary>
    public static class WebRequestExtensions
    {
        /// <summary>
        /// Support cancelling a webrequest using a cancellation token 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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