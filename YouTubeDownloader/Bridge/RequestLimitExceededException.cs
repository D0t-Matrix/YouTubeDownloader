using System.Runtime.Serialization;

namespace YouTubeDownloader.Bridge
{
    [Serializable]
    internal class RequestLimitExceededException : Exception
    {
        public RequestLimitExceededException()
        {
        }

        public RequestLimitExceededException(string? message) : base(message)
        {
        }

        public RequestLimitExceededException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RequestLimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}