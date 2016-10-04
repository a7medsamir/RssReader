using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Shared.Helpers;

namespace Shared.Model
{
    public class Feed
    {
       public FeedType FeedType { get; set; }
        public string Url { get; set; }
        public string DisplayName { get; set; }

        public ObservableCollection<Item> FeedArticles { get; set; }
    }
}
