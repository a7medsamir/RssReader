using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Shared.Helpers;
using Shared.Model;

namespace Shared.ViewModel
{
    public class FeedDataSource
    {
        private readonly string XmlFilePath = "..\\..\\Data\\myFeeds.xml";
        public ObservableCollection<Feed> GetAllFeeds()
        {
            ObservableCollection<Feed> listCollectionFeeds = new ObservableCollection<Feed>();
            //Retrive all feeds from xml 
            XDocument doc = XDocument.Load(XmlFilePath);
            var feeds = doc.Descendants("Feed");
            foreach (var feed in feeds)
            {
                listCollectionFeeds.Add(new Feed()
                {
                   // FeedType = !string.IsNullOrEmpty(feed.Attribute("FeedType").Value)?((FeedType))Enum.Parse(typeof(FeedType), feed.Attribute("FeedType").Value):FeedType.RSS),
                    Url = new Uri(feed.Attribute("Url").Value),
                    DisplayName = feed.Attribute("DisplayName").Value
                });
            }
            return listCollectionFeeds;
        }

        public bool AddFeed(object newFeed)
        {
            if (newFeed == null) return false;

            Feed feed = (newFeed as Feed);
            XDocument doc = XDocument.Load(XmlFilePath);
            XElement root = new XElement("Feed");
            root.Add(new XAttribute("FeedType", feed.FeedType.ToString()));
            root.Add(new XAttribute("Url", feed.Url));
            root.Add(new XAttribute("DisplayName", feed.DisplayName ));
            doc.Element("Feeds").Add(root);
            doc.Save(XmlFilePath);
            return true;
        }
    }
}