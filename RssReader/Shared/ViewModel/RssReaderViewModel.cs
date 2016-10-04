using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Helpers;
using Shared.Model;

namespace Shared.ViewModel
{
    public class RssReaderViewModel : ViewModelBase
    {

        #region Constructors
        public RssReaderViewModel()
        {
            _feeds = _dataSource.GetAllFeeds();


            AddFeedCommand = new RelayCommand(AddFeed);
        }
        #endregion

        #region Private Members
        private ObservableCollection<Feed> _feeds = new ObservableCollection<Feed>();
        private Feed _newFeed = new Feed();
        private Feed _selectedFeed = null;
        private Item _selectedArticle = null;
        private FeedDataSource _dataSource = new FeedDataSource();
        #endregion

        #region Public Properties
        public ObservableCollection<Feed> Feeds
        {
            get { return _feeds; }
            set
            {
                _feeds = value;
                RaisePropertyChanged("Feeds");
            }
        }

        public Feed SelectedFeed
        {
            get
            {
                return _selectedFeed;
            }
            set
            {
                if (_selectedFeed != value)
                {
                    _selectedFeed = value;
                    if(!string.IsNullOrEmpty(_selectedFeed.Url))
                        _selectedFeed.FeedArticles = _dataSource.LoadFeedArticles(_selectedFeed.Url, _selectedFeed.FeedType);
                    RaisePropertyChanged("SelectedFeed");
                }
            }
        }


        public Item SelectedArticle
        {
            get { return _selectedArticle; }
            set
            {
                if (_selectedArticle != value)
                {
                    _selectedArticle = value;
                    RaisePropertyChanged("SelectedArticle");
                }
            }
        }
        public Feed NewFeed
        {
            get
            {
                return _newFeed;
            }
            set
            {
                if (_newFeed != value)
                {
                    _newFeed = value;
                    RaisePropertyChanged("NewFeed");
                }
            }
        }

        public RelayCommand AddFeedCommand { get; set; }

        #endregion

        private void AddFeed(object addedObject)
        {
            var isDone = _dataSource.AddFeed(addedObject);
            if (isDone)
            {
                NewFeed = new Feed();
                Feeds = _dataSource.GetAllFeeds();
            }
        }
    }
}
