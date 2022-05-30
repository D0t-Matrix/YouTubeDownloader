namespace YouTubeDownloader.Exceptions
{
    /// <summary>
    /// Exception thrown when the requested video is unavailable
    /// </summary>
    public class VideoUnavailableException : VideoUnplayableException
    {
        /// <summary>
        /// Initializes an instance of <see cref="VideoUnavailableException"/>
        /// </summary>
        /// <param name="message"></param>
        public VideoUnavailableException(string message) : base(message)
        {

        }
    }
}
