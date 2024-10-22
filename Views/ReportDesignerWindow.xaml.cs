using DevExpress.XtraReports.UI;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace SHEndevour.Views
{
    /// <summary>
    /// Lógica de interacción para ReportDesignerWindow.xaml
    /// </summary>
    public partial class ReportDesignerWindow : Window
    {

        private XtraReport currentReport;

        public ReportDesignerWindow()
        {
            InitializeComponent();
        }

        // Método para cargar una plantilla de reporte desde un archivo .repx
        public void LoadReport(string filePath)
        {
            var report = new XtraReport();
            report.LoadLayout(filePath);
            reportDesigner.OpenDocument(report);
        }

        public void SaveReport(string filePath)
        {
            // Verifica si hay un reporte cargado
            if (currentReport != null)
            {
                // Guarda la plantilla en el archivo especificado
                currentReport.SaveLayout(filePath);
            }
            else
            {
                MessageBox.Show("No hay ningún reporte cargado para guardar.", "Guardar Reporte", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnLoadReportButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Report Files (*.repx)|*.repx";

            // Comparación correcta en WPF
            if (openFileDialog.ShowDialog() == true)
            {
                LoadReport(openFileDialog.FileName);
            }
        }

        private void OnSaveReportButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Report Files (*.repx)|*.repx";

            // Comparación correcta en WPF
            if (saveFileDialog.ShowDialog() == true)
            {
                SaveReport(saveFileDialog.FileName);
            }
        }


    }
}