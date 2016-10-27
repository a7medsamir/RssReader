using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Shared.Helpers;

namespace Shared.Model
{
    /// <summary>
    /// class represent model for feed
    /// </summary>
    public class Feed
    {
        /// <summary>
        /// Type  of feed
        /// </summary>
        public FeedType FeedType { get; set; }
        /// <summary>
        /// Url of feed
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// display name of feed
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        ///  list of articled for feed
        /// </summary>
        public ObservableCollection<Item> FeedArticles { get; set; }
    }
}
