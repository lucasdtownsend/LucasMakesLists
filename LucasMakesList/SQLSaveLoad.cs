using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace LucasMakesList
{
    public static class SQLSaveLoad
    {
        #region Public Properties
        public static string DBPath
        {
            get
            {
                return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "appdata.sqlite");
            }
        }

        private static SQLiteConnection _dbconnection;
        private static SQLiteConnection dbconnection
        {
            get
            {
                if (_dbconnection == null)
                {
                    _dbconnection = new SQLiteConnection(DBPath);
                }
                return _dbconnection;
            }
        }

        private static TableMapping _lucasListMap;
        private static TableMapping LucasListMap
        {
            get
            {
                if (_lucasListMap == null)
                {
                    _lucasListMap = new TableMapping(typeof(LucasList));
                }
                return _lucasListMap;
            }
        }

        private static TableMapping _lucasListItemMap;
        private static TableMapping LucasListItemMap
        {
            get
            {
                if (_lucasListItemMap == null)
                {
                    _lucasListItemMap = new TableMapping(typeof(LucasListItem));
                }
                return _lucasListItemMap;
            }
        }
        #endregion Public Properties

        #region Public Methods
        public static void SaveLists(ObservableCollection<LucasList> lists)
        {
            for (int i = 0; i < lists.Count; i++)
            {
                LucasList currentList = lists[i];
                SaveList(currentList, dbconnection);
            }
        }

        public static void SaveList(LucasList currentList)
        {
            SaveList(currentList, dbconnection);
        }

        public static void SaveList(LucasList currentList, SQLiteConnection dbconnection)
        {
            // Check if this is a new row
            if (currentList.HasBeenSaved)
            {
                // If it does exist, update it
                //dbconnection.Query(LucasListMap, string.Format("UPDATE LucasList SET Title='{0}',ListOrder={1} WHERE Id={2}", new object[] { currentList.Title, currentList.ListOrder, currentList.Id }));
                try
                {
                    dbconnection.Update(currentList);
                }
                catch
                {
                    // TODO: Save this error somewhere
                }
            }
            else
            {
                // If it doesn't exist, create it
                //dbconnection.Query(LucasListMap, "INSERT INTO LucasList (Title,ListOrder) VALUES (?,?)", new object[] { currentList.Title, currentList.ListOrder });
                dbconnection.Insert(currentList);

                // Get the rowid for the row we just inserted (this is bad, but it works in our case)
                List<object> newRows = dbconnection.Query(LucasListMap, "SELECT Id FROM LucasList ORDER BY Id DESC");
                int newRowID = (int)((LucasList)newRows[0]).Id;

                // Set some properties on the object to show it's been saved
                currentList.Id = newRowID;
                currentList.HasBeenSaved = true;
            }
            
            // Loop through LucasList items
            foreach (LucasListItem currentItem in currentList.Items)
            {
                if (currentItem.HasBeenSaved)
                {
                    // If it does exist, update it
                    //dbconnection.Query(LucasListItemMap, string.Format("UPDATE LucasListItem SET Title='{0}',ListOrder={1},ListID={2},Description='{3}' WHERE Id={4}", new object[] { currentItem.Title, currentItem.ListOrder, currentItem.ListID, currentItem.Description, currentItem.Id }));

                    try
                    {
                        dbconnection.Update(currentItem);
                    }
                    catch
                    {
                        // TODO: Save this error somewhere
                    }
                }
                
                else
                {
                    // If it doesn't exist, create it
                    //List<object> newRows = dbconnection.Query(LucasListItemMap, "INSERT INTO LucasListItem (Title,ListOrder,ListID,Description) VALUES (?,?,?,?)", new object[] { currentItem.Title, currentItem.ListOrder, currentItem.ListID, currentItem.Description });
                    dbconnection.Insert(currentItem);

                    // Get the rowid for the row we just inserted (this is bad, but it works in our case)
                    List<object> newRows = dbconnection.Query(LucasListItemMap, "SELECT Id FROM LucasListItem ORDER BY Id DESC");
                    int newRowID = (int)((LucasListItem)newRows[0]).Id;

                    // Set some properties on the object to show it's been saved
                    currentItem.Id = newRowID;
                    currentItem.HasBeenSaved = true;
                }
            }
        }

        public static ObservableCollection<LucasList> LoadLists()
        {
            // Create the return value
            ObservableCollection<LucasList> lucasLists = new ObservableCollection<LucasList>();

            // Get LucasLists from database
            List<object> lucasListsFromQuery = dbconnection.Query(LucasListMap, "SELECT * FROM LucasList ORDER BY ListOrder ASC");

            // Load LucasLists into return value
            foreach (object currentList in lucasListsFromQuery)
            {
                LucasList currentLucasList = (LucasList)currentList;
                currentLucasList.HasBeenSaved = true;
                lucasLists.Add(currentLucasList);
            }

            // Get LucasListItems from database for each LucasList in return value
            foreach (LucasList currentList in lucasLists)
            {
                // Get LucasListItems for the current list from database
                List<object> lucasListItemsFromQuery = dbconnection.Query(LucasListItemMap, string.Format("SELECT * FROM LucasListItem WHERE ListId={0} ORDER BY ListOrder ASC", new object[] { currentList.Id }));

                // Load LucasListItems into current LucasList
                foreach (object currentItem in lucasListItemsFromQuery)
                {
                    LucasListItem currentLucasListItem = (LucasListItem)currentItem;
                    currentLucasListItem.HasBeenSaved = true;
                    currentList.Items.Add(currentLucasListItem);
                }
            }

            return lucasLists;
        }

        public static void UpdateListItem(LucasListItem item)
        {
            try
            {
                dbconnection.Update(item);
            }
            catch
            {
                // TODO: Save this error somewhere
            }
        }

        public static void DeleteListItem(LucasListItem item)
        {
            try
            {
                dbconnection.Delete(item);
            }
            catch
            {
                // TODO: Save this error somewhere
            }
        }

        public static void DeleteList(LucasList list)
        {
            // First remove all list items
            foreach (LucasListItem item in list.Items)
            {
                DeleteListItem(item);
            }

            try
            {
                dbconnection.Delete(list);
            }
            catch
            {
                // TODO: Save this error somewhere
            }
        }
        #endregion Public Methods
    }
}
