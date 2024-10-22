﻿using SHEndevour.Views.Settings.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SHEndevour.Views.Settings.General;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views.Settings
{
    /// <summary>
    /// Lógica de interacción para GeneralSetting.xaml
    /// </summary>
    public partial class GeneralSetting : UserControl
    {
        public GeneralSetting()
        {
            InitializeComponent();
            GeneralConfigureView.Content = new ConfigurarInterfaz();
            UINavButton.IsChecked = true;

            Loaded += CustomControl_Loaded;  // Suscribe al evento Loaded
        }

        // Se llama cuando el UserControl está completamente cargado
        private void CustomControl_Loaded(object sender, EventArgs e)
        {
            // Aplica los permisos del usuario actual a este UserControl
            App.PermissionService?.ApplyPermissions(this);
        }
        private void GeneralNavButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is System.Windows.Controls.RadioButton button) // Verificación de que el sender es un Button
            {
                string tag = button.Tag?.ToString() ?? string.Empty; // Manejo de nulo con ?? y ?? operator

                switch (tag)
                {
                    case "Interfaz":
                        GeneralConfigureView.Content = new ConfigurarInterfaz();
                        break;


                    default:
                        // Manejar un valor de tag no esperado si es necesario
                        break;
                }

            }
        }
    }
}
