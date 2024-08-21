using SHEndevour.ViewModels;
using System.Windows;
using System.Windows.Controls;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views
{
    public partial class UserView : UserControl
    {
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


    }

}
