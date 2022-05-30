using System.Xml.Linq;

using YouTubeDownloader.Utils;

namespace YouTubeDownloader.Bridge
{
    internal partial class DashManifestExtractor
    {
        private readonly XElement _content;

        public DashManifestExtractor(XElement content) => _content = content;

        public IReadOnlyList<IStreamInfoExtractor> GetStreams() => Memo.Cache(this, () =>
            _content
                .Descendants("Representation")
                // Skip non-media representations (like "rawcc")
                .Where(x => x
                    .Attribute("id")?
                    .Value
                    .All(char.IsDigit) == true)
                // Skip segmented streams
                .Where(x => x
                    .Descendants("Initialization")
                    .FirstOrDefault()?
                    .Attribute("sourceURL")?
                    .Value
                    .Contains("sq/") != true)
                // Skip streams without codecs
                .Where(x => !string.IsNullOrWhiteSpace(x.Attribute("codecs")?.Value))
                .Select(x => new DashStreamInfoExtractor(x))
                .ToArray()
        );
    }

    internal partial class DashManifestExtractor
    {
        public static DashManifestExtractor Create(string raw) => new(Xml.Parse(raw));
    }
}
