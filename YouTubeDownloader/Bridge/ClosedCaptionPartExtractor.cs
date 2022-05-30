using System.Xml.Linq;
using YouTubeDownloader.Utils;
using YouTubeDownloader.Utils.Extensions;

namespace YouTubeDownloader.Bridge
{
    internal class ClosedCaptionPartExtractor
    {
        private readonly XElement _content;

        public ClosedCaptionPartExtractor(XElement content) => _content = content;

        public string? TryGetText() => Memo.Cache(this, () =>
            (string?)_content
        );

        public TimeSpan? TryGetOffset() => Memo.Cache(this, () =>
            ((double?)_content.Attribute("t"))?.Pipe(TimeSpan.FromMilliseconds) ??
            ((double?)_content.Attribute("ac"))?.Pipe(TimeSpan.FromMilliseconds) ??
            TimeSpan.Zero
        );
    }
}
