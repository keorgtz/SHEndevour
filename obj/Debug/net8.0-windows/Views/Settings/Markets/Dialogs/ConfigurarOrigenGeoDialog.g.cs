﻿#pragma checksum "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0E277D7237AAC7AF74CC19C53EE8AFE183D88279"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SHEndevour.Views.Settings.Markets.Dialogs;
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


namespace SHEndevour.Views.Settings.Markets.Dialogs {
    
    
    /// <summary>
    /// ConfigurarOrigenGeoDialog
    /// </summary>
    public partial class ConfigurarOrigenGeoDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AddEditSubtitle;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GeoKeyTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SHEndevour;component/views/settings/markets/dialogs/configurarorigengeodialog.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
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
            this.GeoKeyTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
            this.GeoKeyTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
            this.DescriptionTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 67 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\..\..\..\Views\Settings\Markets\Dialogs\ConfigurarOrigenGeoDialog.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.OnAcceptClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

