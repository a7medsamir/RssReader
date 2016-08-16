using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Helpers;

namespace SharedTest
{
    [TestClass]
    public class FeedParserTest
    {
        [TestMethod]
        public void ParseTest()
        {
            FeedParser parser = new FeedParser();
            var result = parser.Parse("http://feeds.hanselman.com/ScottHanselman", FeedType.RSS);
            Assert.IsTrue(result != null && result.Count > 0);
        }
    }
}
