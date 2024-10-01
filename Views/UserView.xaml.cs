using SHEndevour.ViewModels;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Printing;
using DevExpress.XtraReports.UI;
using UserControl = System.Windows.Controls.UserControl;
using SHEndevour.Repositories.Reports;

namespace SHEndevour.Views
{
    public partial class UserView : UserControl
    {
         // Columna por defecto para la búsqueda
        public UserView()
        {
            InitializeComponent();
            this.DataContext = new UserManagementViewModel();
        }

    }

}
