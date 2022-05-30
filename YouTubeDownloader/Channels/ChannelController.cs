using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeDownloader.Bridge;
using YouTubeDownloader.Exceptions;

namespace YouTubeDownloader.Channels
{
    internal class ChannelController : YoutubeControllerBase
    {
        public ChannelController(HttpClient http)
            : base(http)
        {
        }

        private async ValueTask<ChannelPageExtractor> GetChannelPageAsync(
            string channelRoute,
            CancellationToken cancellationToken = default)
        {
            var url = $"https://www.youtube.com/{channelRoute}?hl=en";

            for (var retry = 0; retry <= 5; retry++)
            {
                var raw = await SendHttpRequestAsync(url, cancellationToken);

                var channelPage = ChannelPageExtractor.TryCreate(raw);
                if (channelPage is not null)
                    return channelPage;
            }

            throw new YoutubeDownloaderException(
                "Channel page is broken. " +
                "Please try again in a few minutes."
            );
        }

        public async ValueTask<ChannelPageExtractor> GetChannelPageAsync(
            ChannelId channelId,
            CancellationToken cancellationToken = default) =>
            await GetChannelPageAsync("channel/" + channelId, cancellationToken);

        public async ValueTask<ChannelPageExtractor> GetChannelPageAsync(
            UserName userName,
            CancellationToken cancellationToken = default) =>
            await GetChannelPageAsync("user/" + userName, cancellationToken);
    }
}
