using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.Exceptions
{
    /// <summary>
    /// Exception thrown within <see cref="YouTubeDownloader"/>
    /// </summary>
    public class YoutubeDownloaderException : Exception
    {
        /// <summary>
        /// Initializes an instance of <see cref="YoutubeDownloaderException"/>
        /// </summary>
        /// <param name="message"></param>
        public YoutubeDownloaderException(string message) : base(message)
        {

        }
    }
}
