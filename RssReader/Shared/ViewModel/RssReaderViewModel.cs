using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Shared.ViewModel
{
    public class RssReaderViewModel
    {

        #region Constructors
        public RssReaderViewModel()
        {
            _feeds = _dataSource.GetAllFeeds();
        }
        #endregion
        
        #region Private Members
        private ObservableCollection<Feed> _feeds = new ObservableCollection<Feed>();
        private Feed _selectedFeed = null;
        private FeedDataSource _dataSource = new FeedDataSource();
        #endregion

        #region Public Properties
        public ObservableCollection<Feed> Feeds
        {
            get { return _feeds; }
            set { _feeds = value; }
        }

        public Feed SelectedFeed
        {
            get { return _selectedFeed; }
            set { _selectedFeed = value; }
        }
        #endregion
    }
}
