using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.Bridge
{
    internal interface IStreamInfoExtractor
    {
        int? TryGetItag();

        string? TryGetUrl();

        string? TryGetSignature();

        string? TryGetSignatureParameter();

        long? TryGetContentLength();

        long? TryGetBitrate();

        string? TryGetContainer();

        string? TryGetAudioCodec();

        string? TryGetVideoCodec();

        string? TryGetVideoQualityLabel();

        int? TryGetVideoWidth();

        int? TryGetVideoHeight();

        int? TryGetFramerate();
    }
}
