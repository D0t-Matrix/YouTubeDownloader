using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.Exceptions
{
    /// <summary>
    /// Exception thrown when YouTube denies a request because the client has exceeded rate limit.
    /// </summary>
    public class RequestLimitExceededException : YoutubeDownloaderException
    {
        /// <summary>
        /// Initializes an instance of <see cref="RequestLimitExceededException"/>.
        /// </summary>
        public RequestLimitExceededException(string message) : base(message)
        {
        }
    }
}
