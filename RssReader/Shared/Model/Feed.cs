using System;
using System.Collections.Generic;
using System.Text;
using Shared.Helpers;

namespace Shared.Model
{
    public class Feed
    {
       public FeedType FeedType { get; set; }
        public Uri Url { get; set; }
        public string DisplayName { get; set; }
    }
}
