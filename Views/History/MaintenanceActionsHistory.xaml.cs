using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
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
using System.Windows.Shapes;
using SHEndevour.AppReports;

namespace SHEndevour.Views.History
{
    /// <summary>
    /// Lógica de interacción para MaintenanceActionsHistory.xaml
    /// </summary>
    public partial class MaintenanceActionsHistory : Window
    {
        public MaintenanceActionsHistory()
        {
            InitializeComponent();
            this.DataContext = new RoomMaintenanceViewModel();
        }

        private void OnPrintPreviewClick(object sender, RoutedEventArgs e)
        {
            // Crear un enlace a los datos del GridControl para la impresión
            var link = new PrintableControlLink(MaintenanceHistoryGrid.View as TableView);


            // Suscribirse al evento para personalizar la barra de herramientas
            link.CreateDocument();

            // Mostrar la vista previa de impresión con opciones limitadas
            link.ShowPrintPreview(this);
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana actual
        }
    }
}
