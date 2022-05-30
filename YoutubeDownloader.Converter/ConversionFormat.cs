using System.Diagnostics.CodeAnalysis;

using YouTubeDownloader.Videos.Streams;

namespace YoutubeDownloader.Converter
{
    /// <summary>
    /// Encapsulates conversion media format.
    /// </summary>
    [Obsolete("Use YoutubeDownloader.Videos.Streams.Container instead"), ExcludeFromCodeCoverage]
    public readonly struct ConversionFormat
    {
        /// <summary>
        /// Format name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Whether this format is a known audio-only format.
        /// </summary>
        public bool IsAudioOnly => new Container(Name).IsAudioOnly();

        /// <summary>
        /// Initializes an instance of <see cref="ConversionFormat"/>.
        /// </summary>
        public ConversionFormat(string name) => Name = name;

        /// <inheritdoc />
        public override string ToString() => Name;
    }
}
