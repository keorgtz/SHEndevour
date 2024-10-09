﻿#pragma checksum "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ADA8910A1530C19274B154F6029CBBCFDB9D81A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SHEndevour.Views.Settings.Rooms.Dialogs {
    
    
    /// <summary>
    /// AddEditMaintenanceDialog
    /// </summary>
    public partial class AddEditMaintenanceDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AddEditSubtitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomKeyTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomStatusComboBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BlockTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDatePicker;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CauseDescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SHEndevour;component/views/settings/rooms/dialogs/addeditmaintenancedialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddEditSubtitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.RoomKeyTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            this.RoomKeyTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 50 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonForSelectRoom_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RoomStatusComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 63 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            this.RoomStatusComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BlockTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 69 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            this.BlockTypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EndDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.CauseDescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 86 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            this.CauseDescriptionTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 98 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\..\..\..\Views\Settings\Rooms\Dialogs\AddEditMaintenanceDialog.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.OnAcceptClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
