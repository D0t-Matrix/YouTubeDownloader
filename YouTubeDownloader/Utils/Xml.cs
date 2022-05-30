using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YouTubeDownloader.Utils.Extensions;

namespace YouTubeDownloader.Utils
{
    internal static class Xml
    {
        public static XElement Parse(string source)
            => XElement.Parse(source, LoadOptions.PreserveWhitespace).StripNamespaces();
    }
}
