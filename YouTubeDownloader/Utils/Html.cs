using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.Utils
{
    internal class Html
    {
        private static readonly HtmlParser htmlParser = new();

        public static IHtmlDocument Parse(string source) => htmlParser.ParseDocument(source);
    }
}
