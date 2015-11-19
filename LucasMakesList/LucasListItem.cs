using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace LucasMakesList
{
    public class LucasListItem:INotifyPropertyChanged
    {
        #region Constructors
        // Basic Constructor
        public LucasListItem()
        {

        }

        // Fully loaded Constrcutor
        public LucasListItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
        #endregion Constructors

        #region Properties
        [SQLite.PrimaryKey]
        public int? Id
        {
            get;
            set;
        }

        public int? ListID
        {
            get;
            set;
        }
        
        // The item's display title
        private string _title;
        public string Title
        {
            get
            {
                // Return the private string
                return _title;
            }
            set
            {
                // Set the private string to the provided value
                _title = value;

                // Fire the PropertyChanged event so the UI can update
                OnPropertyChanged("Title");
            }
        }

        // The description of the item shown in sub-menu
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
                SQLSaveLoad.UpdateListItem(this);
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

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion Events
    }
}
