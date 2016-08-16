using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Shared.Model
{
    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
