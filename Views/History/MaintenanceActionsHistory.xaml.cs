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

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Aplica los permisos del usuario actual a esta ventana
            App.PermissionService?.ApplyPermissions(this);
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =


        private void OnPrintPreviewClick(object sender, RoutedEventArgs e)
        {
            // Crear un enlace a los datos del GridControl para la impresión
            var link = new PrintableControlLink(MaintenanceHistoryGrid.View as TableView);

            // Configurar la orientación de la página a horizontal
            link.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4; // Ajustar tamaño de papel
            link.Landscape = true; // Establecer en horizontal

            // Crear el documento para la impresión
            link.CreateDocument();

            // Mostrar la vista previa de impresión con orientación horizontal y personalizado
            link.ShowPrintPreview(this);
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana actual
        }
    }
}
