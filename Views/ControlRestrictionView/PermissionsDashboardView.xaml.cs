using SHEndevour.ViewModels;
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
using System.Windows.Shapes;
using SHEndevour.ViewModels.ControlRestrictionVM;

namespace SHEndevour.Views.ControlRestrictionView
{
    /// <summary>
    /// Lógica de interacción para PermissionsDashboardView.xaml
    /// </summary>
    public partial class PermissionsDashboardView : Window
    {
        public PermissionsDashboardView()
        {
            InitializeComponent();
            this.DataContext = new PermissionsDashboardViewModel();
        }
    }
}
