using SHEndevour.ViewModels;
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
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Grid;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views.Settings.Rooms
{
    /// <summary>
    /// Lógica de interacción para ConfigurarMantenimientoHabitacion.xaml
    /// </summary>
    public partial class ConfigurarMantenimientoHabitacion : UserControl
    {
        public ConfigurarMantenimientoHabitacion()
        {
            InitializeComponent();
            this.DataContext = new RoomMaintenanceViewModel();
        }

        private void OnPrintPreviewClick(object sender, RoutedEventArgs e)
        {
            // Crear un enlace a los datos del GridControl para la impresión
            var link = new PrintableControlLink(MaintenanceRoomsGrid.View as TableView);

            // Mostrar la vista previa de impresión
            link.ShowPrintPreview(this);
        }



    }
}
