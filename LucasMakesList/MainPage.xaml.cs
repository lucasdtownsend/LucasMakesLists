using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class MainPage : Page
    {
        #region Constructors
        public MainPage()
        {
            this.InitializeComponent();

            LucasLists = SQLSaveLoad.LoadLists();
            LucasLists.CollectionChanged += LucasLists_CollectionChanged;
            TransitionOut.Completed += TransitionOut_Completed;


            DataContext = LucasLists;

            // Prevent page from being cleared when navigating forward to subpage
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private bool _isFirstLoad = true;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            if (_isFirstLoad)
            {
                _isFirstLoad = false;
            }
            else
            {
                TransitionIn.Begin();
            }
        }
        #endregion Constructors

        #region Properties
        private ObservableCollection<LucasList> LucasLists
        {
            get;
            set;
        }

        private bool IsSavingChanges
        {
            get;
            set;
        }

        private LucasList NavigatedList
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

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Close the dialog
            NavigateToSubPage((LucasList)e.ClickedItem);
        }

        private void newItemDialog_OKPressed(object sender, EventArgs e)
        {
            // Create the new lucaslist
            LucasList newList = new LucasList();
            newList.Title = newItemDialog.NewItemName;
            LucasLists.Add(newList);
            
            // Navigate to the subpage
            NavigateToSubPage(newList);
        }

        private void newItemDialog_CancelPressed(object sender, EventArgs e)
        {
            dialogContainer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        void LucasLists_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Save lists to database
            // ListView control removes and then adds instead of a single move event, so for the time being
            // we're only calling this on the Add event to avoid two rapid calls in a row.
            if (!IsSavingChanges && e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Fill in the listorder
                for (int i = 0; i < LucasLists.Count; i++)
                {
                    LucasLists[i].ListOrder = i;
                }

                // Save the changes
                SaveLists();
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (object lucasList in listView.SelectedItems)
            {
                SQLSaveLoad.DeleteList((LucasList)lucasList);
                LucasLists.Remove((LucasList)lucasList);
            }
            
        }
        #endregion Control Event Handlers

        #region Private Methods
        private async void SaveLists()
        {
            IsSavingChanges = true;

            await System.Threading.Tasks.Task.Run(() => SQLSaveLoad.SaveLists(LucasLists));

            IsSavingChanges = false;
        }

        private void NavigateToSubPage(LucasList navigatedList)
        {
            NavigatedList = navigatedList;
            TransitionOut.Begin();
        }

        void TransitionOut_Completed(object sender, object e)
        {
            // Close the dialog
            dialogContainer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            this.Frame.Navigate(typeof(SubPage), NavigatedList);
        }
        #endregion Private Methods

    }
}
