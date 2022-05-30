using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YouTubeDownloader.Utils;
using YouTubeDownloader.Utils.Extensions;

namespace YouTubeDownloader.Bridge
{
    internal class SearchResultChannelExtractor
    {
        private readonly JsonElement _content;

        public SearchResultChannelExtractor(JsonElement content) =>
            _content = content;

        public string? TryGetChannelId() => Memo.Cache(this, () =>
            _content
                .GetPropertyOrNull("channelId")?
                .GetStringOrNull()
        );

        public string? TryGetChannelTitle() => Memo.Cache(this, () =>
            _content
                .GetPropertyOrNull("title")?
                .GetPropertyOrNull("simpleText")?
                .GetStringOrNull() ??

            _content
                .GetPropertyOrNull("title")?
                .GetPropertyOrNull("runs")?
                .EnumerateArrayOrNull()?
                .Select(j => j.GetPropertyOrNull("text")?.GetStringOrNull())
                .WhereNotNull()
                .ConcatToString()
        );

        public IReadOnlyList<ThumbnailExtractor> GetChannelThumbnails() => Memo.Cache(this, () =>
            _content
                .GetPropertyOrNull("thumbnail")?
                .GetPropertyOrNull("thumbnails")?
                .EnumerateArrayOrNull()?
                .Select(j => new ThumbnailExtractor(j))
                .ToArray() ??

            Array.Empty<ThumbnailExtractor>()
        );
    }
}
