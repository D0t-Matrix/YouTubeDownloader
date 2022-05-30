using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.Exceptions
{
    /// <summary>
    /// Exception thrown when the requested playlist is unavailable.
    /// </summary>
    public class PlaylistUnavailableException : YoutubeDownloaderException
    {
        /// <summary>
        /// Initializes instance of <see cref="PlaylistUnavailableException"/>
        /// </summary>
        /// <param name="message"></param>
        public PlaylistUnavailableException(string message) : base(message)
        {

        }
    }
}
