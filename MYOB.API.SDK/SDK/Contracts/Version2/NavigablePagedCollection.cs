using System;
#if ASYNC
using System.Threading;
using System.Threading.Tasks;
#endif

namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Extends PagedCollection<> to allow navigation to the next page
    /// </summary>
    /// <typeparam name="T">The type of entities that have been returned</typeparam>
    /// <remarks>
    /// If NextPageLink is not populated here the NextPage method will return null
    /// </remarks>
    public class NavigablePagedCollection<T>
        : PagedCollection<T>
        where T : class
    {
        private readonly NextPageDelegate _nextPage;
        internal delegate PagedCollection<T> NextPageDelegate(
            Uri uri,
            string eTag);

#if ASYNC
        private readonly NextPageAsyncDelegate _nextPageAsync;
        internal delegate Task<PagedCollection<T>> NextPageAsyncDelegate(
            Uri uri,
            CancellationToken cancellationToken,
            string eTag);

        internal NavigablePagedCollection(
            PagedCollection<T> pagedCollection,
            NextPageDelegate nextPage,
            NextPageAsyncDelegate nextPageAsync)
        {
            _nextPage = nextPage;
            _nextPageAsync = nextPageAsync;
            Items = pagedCollection.Items;
            NextPageLink = pagedCollection.NextPageLink;
            Count = pagedCollection.Count;
            ETag = pagedCollection.ETag;
        }
#else
        internal NavigablePagedCollection(
            PagedCollection<T> pagedCollection,
            NextPageDelegate nextPage)
        {
            _nextPage = nextPage;
            Items = pagedCollection.Items;
            NextPageLink = pagedCollection.NextPageLink;
            Count = pagedCollection.Count;
            ETag = pagedCollection.ETag;
        }
#endif

        public NavigablePagedCollection<T> NextPage(string eTag = null)
        {
            if (NextPageLink == null) return null;
            var pagedCollection = _nextPage(NextPageLink, eTag);
            return FromPagedCollection(pagedCollection);
        }

        public async Task<NavigablePagedCollection<T>> NextPageAsync(
            CancellationToken cancellationToken,
            string eTag = null)
        {
            if (NextPageLink == null) return null;
            var pagedCollection = await _nextPageAsync(
                NextPageLink,
                cancellationToken,
                eTag);
            return FromPagedCollection(pagedCollection);

        }

        public Task<NavigablePagedCollection<T>> NextPageAsync(string eTag = null)
        {
            return NextPageAsync(CancellationToken.None, eTag);
        }

        private NavigablePagedCollection<T> FromPagedCollection(
            PagedCollection<T> pagedCollection)
        {
#if ASYNC
            return new NavigablePagedCollection<T>(
                pagedCollection,
                _nextPage,
                _nextPageAsync);
#else
            return new NavigablePagedCollection<T>(
                pagedCollection,
                _nextPage);
#endif
        }
    }
}