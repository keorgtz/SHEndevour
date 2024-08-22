﻿#pragma checksum "..\..\..\..\Views\AddEditUserDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31DA9C513938B0E427A8D7A2EF0121AD1CBF0D41"
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


namespace SHEndevour.Views {
    
    
    /// <summary>
    /// AddEditUserDialog
    /// </summary>
    public partial class AddEditUserDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AddEditSubtitle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PassBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Views\AddEditUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoleComboBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Views\AddEditUserDialog.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SHEndevour;component/views/addedituserdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AddEditUserDialog.xaml"
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
            this.UsernameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.UsernameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PassBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 39 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.PassBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FirstNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.FirstNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LastNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.LastNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.EmailTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 73 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.PhoneTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            
            #line 74 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.PhoneTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PhoneTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RoleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.RoleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnRoleSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\Views\AddEditUserDialog.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.OnAcceptClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

