using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LucasMakesList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubPage : Page
    {
        #region Constructors
        public SubPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Grab the LucasList passed in from the previous page and set it as the DataContext
            LucasList = (LucasList)e.Parameter;
            DataContext = LucasList;

            LucasList.Items.CollectionChanged += Items_CollectionChanged;
            TransitionOut.Completed += TransitionOut_Completed;

            TransitionIn.Begin();
        }
        #endregion Constructors

        #region Properties
        private LucasList LucasList
        {
            get;
            set;
        }

        private bool IsSavingChanges
        {
            get;
            set;
        }
        #endregion Properties

        #region Control Event Handlers
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Show dialog
            OpenDialog.Begin();
            dialogContainer.Visibility = Windows.UI.Xaml.Visibility.Visible;
            newItemDialog.FocusTextbox();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBack();
        }

        private void newItemDialog_OKPressed(object sender, EventArgs e)
        {
            // Close the dialog
            dialogContainer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            // Create the new lucaslistitem
            LucasListItem newItem = new LucasListItem();
            newItem.Title = newItemDialog.NewItemName;
            newItem.ListID = LucasList.Id;
            LucasList.Items.Add(newItem);
        }

        private void newItemDialog_CancelPressed(object sender, EventArgs e)
        {
            dialogContainer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Save this list to the database
            // ListView control removes and then adds instead of a single move event, so for the time being
            // we're only calling this on the Add event to avoid two rapid calls in a row.
            if (!IsSavingChanges && e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Fill in the listorder
                for (int i = 0; i < LucasList.Items.Count; i++)
                {
                    LucasList.Items[i].ListOrder = i;
                }

                // Save the changes
                SaveList();
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenDetailsPane((LucasListItem)e.ClickedItem);
        }

        private void btnCloseDetailsPane_Click(object sender, RoutedEventArgs e)
        {
            CloseDetailsPane();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDetailsPane();

            LucasListItem deletedItem = null;
            try
            {
                deletedItem = (LucasListItem)((Button)e.OriginalSource).DataContext;
            }
            catch { }

            if (deletedItem != null)
            {
                SQLSaveLoad.DeleteListItem(deletedItem);
                LucasList.Items.Remove(deletedItem);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (object lucasListItem in listView.SelectedItems)
            {
                SQLSaveLoad.DeleteListItem((LucasListItem)lucasListItem);
                LucasList.Items.Remove((LucasListItem)lucasListItem);
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                btnDelete.Visibility = Windows.UI.Xaml.Visibility.Visible;
                listView.IsItemClickEnabled = false;
            }
            else
            {
                btnDelete.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                listView.IsItemClickEnabled = true;
            }
        }
        #endregion Control Event Handlers

        #region Private Methods
        private async void SaveList()
        {
            IsSavingChanges = true;

            await System.Threading.Tasks.Task.Run(() => SQLSaveLoad.SaveList(LucasList));

            IsSavingChanges = false;
        }

        private void NavigateBack()
        {
            TransitionOut.Begin();
        }

        void TransitionOut_Completed(object sender, object e)
        {
            this.Frame.GoBack();
        }

        private void OpenDetailsPane(LucasListItem item)
        {
            detailsPane.DataContext = item;
            OpenPane.Begin();
        }

        private void CloseDetailsPane()
        {
            ClosePane.Begin();
        }
        #endregion Private Methods
    }
}
