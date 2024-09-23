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


        #region CheckAllUsers-Region

        private void HeaderCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Obtén la colección de usuarios desde el DataContext
            var viewModel = DataContext as UserManagementViewModel;

            if (viewModel != null)
            {
                foreach (var user in viewModel.Users)
                {
                    user.IsSelected = true;
                }

                // Forzar la actualización visual del DataGrid
                UserDataGrid.Items.Refresh();

            }
        }

        private void HeaderCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Obtén la colección de usuarios desde el DataContext
            var viewModel = DataContext as UserManagementViewModel;

            if (viewModel != null)
            {
                foreach (var user in viewModel.Users)
                {
                    user.IsSelected = false;
                }

                // Forzar la actualización visual del DataGrid
                UserDataGrid.Items.Refresh();

            }
        }



        #endregion

        private void UserDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            
        }
    }

}
