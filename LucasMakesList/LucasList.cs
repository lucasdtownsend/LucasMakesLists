using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace LucasMakesList
{
    public class LucasList:INotifyPropertyChanged
    {
        #region Constructors
        public LucasList()
        {
            Items = new ObservableCollection<LucasListItem>();
            Items.CollectionChanged += Items_CollectionChanged;
        }
        #endregion Constructors

        #region Properties
        [SQLite.PrimaryKey] 
        public int? Id
        {
            get;
            set;
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private ObservableCollection<LucasListItem> _items;
        [SQLite.Ignore]
        public ObservableCollection<LucasListItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        [SQLite.Ignore]
        public int ItemCount
        {
            get
            {
                return Items.Count;
            }
        }

        public int ListOrder
        {
            get;
            set;
        }

        [SQLite.Ignore]
        public bool HasBeenSaved
        {
            get;
            set;
        }
        #endregion Properties

        #region Event Handlers
        void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("ItemCount");
        }
        #endregion Event Handlers

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion Event
    }
}
