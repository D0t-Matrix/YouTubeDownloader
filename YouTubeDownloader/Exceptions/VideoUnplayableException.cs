using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.Exceptions
{
    public class VideoUnplayableException : YoutubeDownloaderException
    {
        /// <summary>
        /// Initializes an instance of <see cref="VideoUnplayableException"/>.
        /// </summary>
        public VideoUnplayableException(string message) : base(message)
        {
        }
    }
}
