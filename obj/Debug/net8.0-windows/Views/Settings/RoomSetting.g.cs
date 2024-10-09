﻿#pragma checksum "..\..\..\..\..\Views\Settings\RoomSetting.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "173B9F5FD622140461B4E8F2E766862711F4CD45"
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
using SHEndevour.Views.Settings;
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


namespace SHEndevour.Views.Settings {
    
    
    /// <summary>
    /// RoomSetting
    /// </summary>
    public partial class RoomSetting : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\Views\Settings\RoomSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton HabitacionesNavButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Views\Settings\RoomSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl RoomConfigureView;
        
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
            System.Uri resourceLocater = new System.Uri("/SHEndevour;component/views/settings/roomsetting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Settings\RoomSetting.xaml"
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
            this.HabitacionesNavButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 23 "..\..\..\..\..\Views\Settings\RoomSetting.xaml"
            this.HabitacionesNavButton.Click += new System.Windows.RoutedEventHandler(this.RoomSettingNav_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 29 "..\..\..\..\..\Views\Settings\RoomSetting.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.RoomSettingNav_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 35 "..\..\..\..\..\Views\Settings\RoomSetting.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.RoomSettingNav_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RoomConfigureView = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

