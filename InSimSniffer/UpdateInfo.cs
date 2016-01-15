using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace InSimSniffer {
    public class UpdateInfo {
        private const string RssUrl = @"http://insimsniffer.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2finsimsniffer";

        public Version Version { get; private set; }
        public Uri Url { get; private set; }

        private static SyndicationFeed LoadSyndicationFeed(string url) {
            using (XmlReader reader = XmlReader.Create(url)) {
                return SyndicationFeed.Load(reader);
            }
        }

        private static SyndicationItem GetLatestRelease(SyndicationFeed syndicationFeed) {
            return (from i in syndicationFeed.Items
                    where i.Title.Text.StartsWith("Released")
                    orderby i.PublishDate descending
                    select i).FirstOrDefault();
        }

        public static UpdateInfo Download() {
            // We parse the latest version from the CodePlex RSS feed. The feed item title looks
            // like this: "Released: InSimSniffer 1.2.8 (Jul 04, 2011)". 
            SyndicationFeed syndicationFeed = LoadSyndicationFeed(RssUrl);
            SyndicationItem lastestRelease = GetLatestRelease(syndicationFeed);

            string[] tokens = lastestRelease.Title.Text.Split();
            if (tokens.Length >= 3) {
                Version version;
                if (Version.TryParse(tokens[2], out version) && lastestRelease.Links.Any()) {
                    return new UpdateInfo {
                        Version = version,
                        Url = lastestRelease.Links[0].Uri,
                    };
                }
            }

            throw new UpdateException(StringResources.UpdateInfoDownloadErrorMessage);
        }
    }
}
