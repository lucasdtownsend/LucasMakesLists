﻿

#pragma checksum "C:\Users\LDT\documents\visual studio 2013\Projects\LucasMakesList\LucasMakesList\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2929551B78672D9162E43BBBBD3D9720"
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
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard OpenDialog; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard TransitionOut; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard TransitionReset; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard CloseDialog; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard TransitionIn; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid animationGrid; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid dialogContainer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Border border; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::LucasMakesList.NewItemDialog newItemDialog; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid header; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid body; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ListView listView; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button btnDelete; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///MainPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            OpenDialog = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("OpenDialog");
            TransitionOut = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("TransitionOut");
            TransitionReset = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("TransitionReset");
            CloseDialog = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("CloseDialog");
            TransitionIn = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("TransitionIn");
            animationGrid = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("animationGrid");
            dialogContainer = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("dialogContainer");
            border = (global::Windows.UI.Xaml.Controls.Border)this.FindName("border");
            newItemDialog = (global::LucasMakesList.NewItemDialog)this.FindName("newItemDialog");
            header = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("header");
            body = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("body");
            listView = (global::Windows.UI.Xaml.Controls.ListView)this.FindName("listView");
            btnDelete = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btnDelete");
        }
    }
}


