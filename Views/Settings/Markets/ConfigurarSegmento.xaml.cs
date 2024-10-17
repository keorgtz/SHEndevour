using SHEndevour.ViewModels.Settings.Rooms;
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
using SHEndevour.ViewModels.Settings.Markets;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views.Settings.Markets
{
    /// <summary>
    /// Lógica de interacción para ConfigurarSegmento.xaml
    /// </summary>
    public partial class ConfigurarSegmento : UserControl
    {
        public ConfigurarSegmento()
        {
            InitializeComponent();
            this.DataContext = new SegmentManagementViewModel();
        }
    }
}
