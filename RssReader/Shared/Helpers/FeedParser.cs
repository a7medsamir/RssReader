using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Shared.Model;

namespace Shared.Helpers
{
    public enum FeedType
    {
        RSS,
        Atom,
        RDF
    }
    /// <summary>
    /// Helper parser method from :
    /// http://www.anotherchris.net/csharp/simplified-csharp-atom-and-rss-feed-parser/
    /// </summary>
    public class FeedParser
    {
        public IList<Item> Parse(string url, FeedType feedType)
        {
            switch (feedType)
            {
                case FeedType.RSS:
                    return ParseRss(url);
                case FeedType.RDF:
                    return ParseRdf(url);
                case FeedType.Atom:
                    return ParseAtom(url);
                default:
                    throw new NotSupportedException(string.Format("{0} is not supported", feedType.ToString()));
            }
        }




        public IList<Item> ParseRss(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);

                var entries =
                    from item in
                        doc.Root.Descendants()
                            .First(i => i.Name.LocalName == "channel")
                            .Elements()
                            .Where(i => i.Name.LocalName == "item")
                    select new Item
                    {
                        Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                        Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                        Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                        PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value)
                    };
                return entries.ToList();
            }
            catch (Exception ex)
            {
                //write to debugger here 
            }
            return new List<Item>();
        }

        private DateTime ParseDate(string value)
        {
            DateTime result;
            if (DateTime.TryParse(value, out result))
            {
                return result;
            }
            return DateTime.MinValue;
        }

        private IList<Item> ParseAtom(string url)
        {
            throw new NotImplementedException();
        }
        private IList<Item> ParseRdf(string url)
        {
            throw new NotImplementedException();
        }
    }
}
