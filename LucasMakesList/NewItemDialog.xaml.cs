using System;
using System.Collections.Generic;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace LucasMakesList
{
    public sealed partial class NewItemDialog : UserControl
    {
        #region Constructors
        public NewItemDialog()
        {
            this.InitializeComponent();
        }
        #endregion Constructors

        #region Properties
        public string NewItemName
        {
            get;
            set;
        }
        #endregion Properties

        #region Public Methods
        public void FocusTextbox()
        {
            txtName.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }
        #endregion Public Methods

        #region Private Methods
        private void CloseDialogOK()
        {
            if (txtName.Text.Length == 0)
            {
                return;
            }

            NewItemName = txtName.Text;
            txtName.Text = "";
            OnOKPressed();
        }
        #endregion Private Methods

        #region Control Event Handlers
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            OnCancelPressed();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            CloseDialogOK();
        }

        private void txtName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                CloseDialogOK();
            }
        }
        #endregion Control Event Handlers

        #region Events
        public event EventHandler OKPressed;
        private void OnOKPressed()
        {
            if (OKPressed != null)
            {
                OKPressed(this, new EventArgs());
            }
        }

        public event EventHandler CancelPressed;
        private void OnCancelPressed()
        {
            if (CancelPressed != null)
            {
                CancelPressed(this, new EventArgs());
            }
        }
        #endregion Events
    }
}
