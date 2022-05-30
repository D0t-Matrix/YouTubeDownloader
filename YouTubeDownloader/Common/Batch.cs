using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeDownloader.Utils.Extensions;

namespace YouTubeDownloader.Common
{
    public class Batch<T> where T : IBatchItem
    {
        public IReadOnlyList<T> Items { get; set; }

        public Batch(IReadOnlyList<T> items) => Items = items;
    }

    internal static class Batch
    {
        public static Batch<T> Create<T>(IReadOnlyList<T> items) where T : IBatchItem 
            => new(items);
    }

    internal static class BatchExtensions
    {
        public static IAsyncEnumerable<T> FlattenAsync<T>(this IAsyncEnumerable<Batch<T>> source)
            where T : IBatchItem
            => source.SelectManyAsync(b => b.Items);
    }
}
