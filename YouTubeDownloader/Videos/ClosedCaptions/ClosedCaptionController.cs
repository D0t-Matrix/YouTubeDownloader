using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeDownloader.Bridge;
using YouTubeDownloader.Utils;
using YouTubeDownloader.Utils.Extensions;

namespace YouTubeDownloader.Videos.ClosedCaptions
{
    internal class ClosedCaptionController : VideoController
    {
        public ClosedCaptionController(HttpClient http)
            : base(http)
        {
        }

        public async ValueTask<ClosedCaptionTrackExtractor> GetClosedCaptionTrackAsync(
            string url,
            CancellationToken cancellationToken = default)
        {
            // Enforce known format
            var urlWithFormat = url
                .Pipe(s => Url.SetQueryParameter(s, "format", "3"))
                .Pipe(s => Url.SetQueryParameter(s, "fmt", "3"));

            var raw = await SendHttpRequestAsync(urlWithFormat, cancellationToken);

            return ClosedCaptionTrackExtractor.Create(raw);
        }
    }
}
