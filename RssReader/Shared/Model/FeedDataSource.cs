using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Shared.Helpers;
using Shared.Model;

namespace Shared.ViewModel
{
    public class FeedDataSource
    {
        public ObservableCollection<Feed> GetAllFeeds()
        {
            ObservableCollection<Feed> listCollectionFeeds = new ObservableCollection<Feed>();
            //Retrive all feeds from xml 
            XDocument doc = XDocument.Load("..\\..\\Data\\myFeeds.xml");
            var feeds = doc.Descendants("Feed");
            foreach (var feed in feeds)
            {
                listCollectionFeeds.Add(new Feed()
                {
                    FeedType = (FeedType)Enum.Parse(typeof(FeedType), feed.Attribute("FeedType").Value),
                    Url = new Uri(feed.Attribute("Url").Value),
                    DisplayName = feed.Attribute("DisplayName").Value
                });
            }
            return listCollectionFeeds;
        }
    }
}