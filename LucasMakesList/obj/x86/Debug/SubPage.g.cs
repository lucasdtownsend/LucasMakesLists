﻿

#pragma checksum "C:\Users\LDT\documents\visual studio 2013\Projects\LucasMakesList\LucasMakesList\SubPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F92017B3FB8D349DD7ECAA03403694EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LucasMakesList
{
    partial class SubPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 201 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnCloseDetailsPane_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 212 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.DeleteButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 192 "..\..\..\SubPage.xaml"
                ((global::LucasMakesList.NewItemDialog)(target)).OKPressed += this.newItemDialog_OKPressed;
                 #line default
                 #line hidden
                #line 192 "..\..\..\SubPage.xaml"
                ((global::LucasMakesList.NewItemDialog)(target)).CancelPressed += this.newItemDialog_CancelPressed;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 174 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.listView_SelectionChanged;
                 #line default
                 #line hidden
                #line 174 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ListView_ItemClick;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 184 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 152 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.BackButton_Click;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 154 "..\..\..\SubPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnDelete_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


