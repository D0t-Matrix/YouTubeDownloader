﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YouTubeDownloader.Utils;

namespace YouTubeDownloader.Bridge
{
    internal partial class ClosedCaptionTrackExtractor
    {
        private readonly XElement _content;

        public ClosedCaptionTrackExtractor(XElement content) => _content = content;

        public IReadOnlyList<ClosedCaptionExtractor> GetClosedCaptions() => Memo.Cache(this, () =>
            _content
                .Descendants("p")
                .Select(x => new ClosedCaptionExtractor(x))
                .ToArray()
        );
    }

    internal partial class ClosedCaptionTrackExtractor
    {
        public static ClosedCaptionTrackExtractor Create(string raw) => new(Xml.Parse(raw));
    }
}
