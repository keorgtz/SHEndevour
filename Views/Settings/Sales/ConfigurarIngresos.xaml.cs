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
using SHEndevour.ViewModels.Settings.Sales;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views.Settings.Sales
{
    /// <summary>
    /// Lógica de interacción para ConfigurarIngresos.xaml
    /// </summary>
    public partial class ConfigurarIngresos : UserControl
    {
        public ConfigurarIngresos()
        {
            InitializeComponent();
            this.DataContext = new IncomeViewModel();
            Loaded += CustomControl_Loaded;  // Suscribe al evento Loaded
        }

        // Se llama cuando el UserControl está completamente cargado
        private void CustomControl_Loaded(object sender, EventArgs e)
        {
            // Aplica los permisos del usuario actual a este UserControl
            App.PermissionService?.ApplyPermissions(this);
        }
    }
}
